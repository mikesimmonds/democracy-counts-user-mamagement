using UserManagement.Domain.Models;

namespace UserManagement.Domain.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();
    Task<List<User>> GetActiveUsersAsync();
    Task<User?> GetUserById(Guid userId);
    Task<User> SetUserActiveState(User user, bool isActive);
}