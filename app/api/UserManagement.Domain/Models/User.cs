namespace UserManagement.Domain.Models;


/**
 * Note: The roles is an array, so this will need conversion to and from comma separated string.
 */

public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public bool Active { get; set; }
    public List<string> Roles { get; set; } = ["user"];
}
