using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SimpleAuth.Domain.Enums;

namespace SimpleAuth.Contracts.Dto;

public class AddUserRequest
{
    [Required(ErrorMessage = "First name required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name required")]
    public string LastName { get; set; }

    [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please put in a valid email")]
    [Required(ErrorMessage = "Email required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password required")]
    public string Password { get; set; }

    [DefaultValue(Gender.PreferNotToSay)]
    public Gender Gender { get; set; }
}
