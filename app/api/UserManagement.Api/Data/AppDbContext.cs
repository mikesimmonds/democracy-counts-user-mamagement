using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Models;

namespace UserManagement.Api.Data;
/**
 * Note: No generated, used reference from a previous project.
 */
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}