using Microsoft.EntityFrameworkCore;
using UserManagement.Api.Data;
using UserManagement.Domain.Models;
using UserManagement.Domain.Repositories;

namespace UserManagement.Api.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    
    public Task<List<User>> GetUsersAsync()
    {
        return context.Users.ToListAsync();
    }

    public Task<List<User>> GetActiveUsersAsync()
    {
        return context.Users
            .Where(user => user.Active)
            .OrderBy(user => user.Name)
            .ToListAsync();
    }

    public Task<User?> GetUserById(Guid userId)
    {
        return context.Users.FirstOrDefaultAsync(user => user.Id == userId);
    }

    public async Task<User> SetUserActiveState(User user, bool isActive)
    {
        user.Active = isActive;
        await context.SaveChangesAsync();
        return user;
    }
}
