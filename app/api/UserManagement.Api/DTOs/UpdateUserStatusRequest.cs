using System.ComponentModel.DataAnnotations;

namespace UserManagement.Api.DTOs;

public class UpdateUserStatusRequestDto
{
    [Required]
    public bool? IsActive { get; set; }
}
