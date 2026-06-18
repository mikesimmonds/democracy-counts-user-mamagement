using UserManagement.Domain.Models;

namespace UserManagement.Domain.Services;

public interface IUserService
{
    Task<List<User>> GetAllActiveUsers();
    Task<List<User>> GetAllUsers();
    Task<User> UpdateUserActiveStatus(Guid userId, bool isActive);
}