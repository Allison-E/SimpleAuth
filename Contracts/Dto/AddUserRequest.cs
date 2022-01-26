using SimpleAuth.Domain.Enums;

namespace SimpleAuth.Contracts.Dto;

public class AddUserRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public Gender Gender { get; set; }
}
