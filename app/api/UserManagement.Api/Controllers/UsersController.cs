using Microsoft.AspNetCore.Mvc;
using UserManagement.Api.DTOs;
using UserManagement.Domain.Models;
using UserManagement.Domain.Services;

namespace UserManagement.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET /api/users
    [HttpGet]
    public async Task<ActionResult<List<UserResponse>>> GetAllUsersAsync()
    {
        var users = await _userService.GetAllUsers();

        var response = users.Select(MapUserResponse).ToList();

        return Ok(response);
    }

    // GET /api/users/active
    [HttpGet("active")]
    public async Task<ActionResult<List<UserResponse>>> GetAllActiveUsersAsync()
    {
        var users = await _userService.GetAllActiveUsers();

        var response = users.Select(MapUserResponse).ToList();

        return Ok(response);
    }

    // PUT /api/users/{id}/status
    [HttpPut("{id:guid}/status")]
    public async Task<ActionResult<UserResponse>> UpdateUserActiveStatusAsync(
        [FromRoute] Guid id,
        [FromBody] UpdateUserStatusRequestDto request)
    {
        var user = await _userService.UpdateUserActiveStatus(
            id,
            request.Active);

        return Ok(MapUserResponse(user));
    }

    private static UserResponse MapUserResponse(User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Active = user.Active
        };
    }
}