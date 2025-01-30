using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

public interface IUserRepository
{
    Task<ApplicationUser?> AddUser(ApplicationUser applicationUser);
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);

}

