using NSubstitute;
using UserManagement.Domain.Exceptions;
using UserManagement.Domain.Models;
using UserManagement.Domain.Repositories;
using UserManagement.Domain.Services;

namespace UserManagement.Tests.Services;

public class UserServiceTests
{
    [Test]
    public async Task UpdateUserActiveStatus_WhenAdminIsDisabled_ThrowsException()
    {
        // Arrange
        var repository = Substitute.For<IUserRepository>();

        var adminUser = new User
        {
            Id = Guid.NewGuid(),
            Name = "Admin User",
            Email = "admin@example.com",
            Active = true,
            Roles = ["Admin"]
        };

        repository
            .GetUserById(adminUser.Id)
            .Returns(adminUser);

        var service = new UserService(repository);

        // Act
        var action = async () => await service.UpdateUserActiveStatus(adminUser.Id, false);

        // Assert
        Assert.That(action, Throws.TypeOf<AdminCannotBeDisabledException>());

        await repository
            .DidNotReceive()
            .SetUserActiveState(Arg.Any<User>(), Arg.Any<bool>());
    }
}
