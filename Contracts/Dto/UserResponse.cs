using SimpleAuth.Domain.Enums;

namespace SimpleAuth.Contracts.Dto;

public class UserResponse
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public Gender Gender { get; set; }
    public DateTime JoinedAt { get; set; }
}
