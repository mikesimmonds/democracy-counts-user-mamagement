namespace UserManagement.Api.DTOs;

public class UserResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public bool Active { get; set; }
}