using System.ComponentModel.DataAnnotations;
using SimpleAuth.Domain.Enums;

namespace SimpleAuth.Contracts.Dto;

public class AddUserRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    public Gender Gender { get; set; }
}
