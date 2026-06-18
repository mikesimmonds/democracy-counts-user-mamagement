using Microsoft.EntityFrameworkCore;
using UserManagement.Api.Data;
using UserManagement.Domain.Models;
using UserManagement.Domain.Repositories;

namespace UserManagement.Api.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public UserRepository()
    {
        
    }
    public Task<List<User>> GetUsersAsync()
    {
        return _context.Users.ToListAsync();
    }

    public Task<List<User>> GetActiveUsersAsync()
    {
        return _context.Users
            .Where(user => user.Active)
            .OrderBy(user => user.Name)
            .ToListAsync();
    }

    public Task<User?> GetUserById(Guid userId)
    {
        return _context.Users.FirstOrDefaultAsync(user => user.Id == userId);
    }

    public async Task<User> SetUserActiveState(User user, bool isActive)
    {
        user.Active = isActive;
        await _context.SaveChangesAsync();
        return user;
    }
}
