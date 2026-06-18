using UserManagement.Domain.Models;

namespace UserManagement.Api.Data;

/**
 * Note: This was fully generated to save time. Logical use of AI as not business-critical (low risk).
 */ 

public static class DatabaseSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Users.Any())
        {
            return;
        }

        var users = new List<User>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Alice Admin",
                Email = "alice@example.com",
                Active = true,
                Roles = ["Admin"]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Ben Carter",
                Email = "ben@example.com",
                Active = true,
                Roles = ["User"]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Chloe Davis",
                Email = "chloe@example.com",
                Active = false,
                Roles = ["User"]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Daniel Evans",
                Email = "daniel@example.com",
                Active = true,
                Roles = ["Manager"]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Emma Foster",
                Email = "emma@example.com",
                Active = true,
                Roles = ["User"]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Frank Green",
                Email = "frank@example.com",
                Active = false,
                Roles = ["User"]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Grace Hall",
                Email = "grace@example.com",
                Active = true,
                Roles = ["User"]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Harry Jones",
                Email = "harry@example.com",
                Active = true,
                Roles = ["Manager"]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Isla King",
                Email = "isla@example.com",
                Active = false,
                Roles = ["User"]
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Jack Lewis",
                Email = "jack@example.com",
                Active = true,
                Roles = ["User"]
            }
        };

        context.Users.AddRange(users);
        context.SaveChanges();
    }
}