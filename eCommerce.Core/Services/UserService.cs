﻿using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UserService(IUserRepository _userRepository,
            IMapper _mapper) : IUserService
{
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        var user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user is null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(user) with
        {
            Success = true,
            Token = "token"
        };
    }
    public async Task<AuthenticationResponse> Register(RegisterRequest registerRequest)
    {
        var user = _mapper.Map<ApplicationUser>(registerRequest);
        //var user = new ApplicationUser
        //{
        //    Email = registerRequest.Email,
        //    Password = registerRequest.Password,
        //    PersonName = registerRequest.PersonName,
        //    Gender = registerRequest.Gender.ToString(),
        //};

        var registerUser = await _userRepository.AddUser(user);

        if (registerUser is null)
        {
            return null;

        }
        //return new AuthenticationResponse(registerUser.UserId,
        //    registerUser.Email,
        //    registerUser.PersonName,
        //    registerUser.Gender,
        //    "token",
        //    Success: true);
        return _mapper.Map<AuthenticationResponse>(registerUser) with
        {
            Success = true,
            Token = "token"
        };
    }
}
