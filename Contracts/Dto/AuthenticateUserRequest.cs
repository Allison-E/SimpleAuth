using System.ComponentModel.DataAnnotations;

namespace SimpleAuth.Contracts.Dto;

public class AuthenticateUserRequest
{
    [EmailAddress(ErrorMessage = "Please put in a valid email")]
    [Required(ErrorMessage = "Email required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password required")]
    public string Password { get; set; }
}
