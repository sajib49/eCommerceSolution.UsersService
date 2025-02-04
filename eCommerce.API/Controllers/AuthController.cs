using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{


    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            this._userService = userService;
        }

       
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if(registerRequest is null)
            {
                return BadRequest("Invalid request");
            }

            var authenticationResponse = await _userService.Register(registerRequest);
            if(authenticationResponse is null || !authenticationResponse.Success)
            {
                return BadRequest(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest is null)
            {
                return BadRequest("Invalid request");
            }

            var authenticationResponse = await _userService.Login(loginRequest);
            if (authenticationResponse is null || !authenticationResponse.Success)
            {
                return Unauthorized(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }
    }
}
