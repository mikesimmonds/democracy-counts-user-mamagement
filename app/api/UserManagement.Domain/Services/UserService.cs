using UserManagement.Domain.Models;
using UserManagement.Domain.Repositories;

namespace UserManagement.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<List<User>> GetAllActiveUsers()
    {
        return _userRepository.GetActiveUsersAsync();
    }

    public Task<List<User>> GetAllUsers()
    {
        return _userRepository.GetUsersAsync();
    }

    public async Task<User> UpdateUserActiveStatus(Guid userId, bool isActive)
    {
        var user = await _userRepository.GetUserById(userId);

        if (user is null)
        {
            throw new KeyNotFoundException($"User with ID '{userId}' was not found.");
        }

        return await _userRepository.SetUserActiveState(user, isActive);
    }
}
