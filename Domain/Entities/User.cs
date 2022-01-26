using SimpleAuth.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SimpleAuth.Domain.Entities;

public class User
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public Gender Gender { get; set; }

    public DateTime JoinedAt { get; set; }
}
