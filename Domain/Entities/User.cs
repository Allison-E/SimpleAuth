using SimpleAuth.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimpleAuth.Domain.Entities;

public class User
{
    [Required(ErrorMessage = "First name required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name required.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email required.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password required.")]
    public string PasswordHash { get; set; }

    public Gender Gender { get; set; }

    public DateTime JoinedAt { get; set; }
}
