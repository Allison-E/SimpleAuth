using entity = SimpleAuth.Domain.Entities;
using System.Linq;
using NUnit.Framework;

namespace SimpleAuth.UnitTests.Domain;

internal class User
{
    [Test]
    public void FirstNameRequired()
    {
        entity.User user = new()
        {
            LastName = "Allison",
        };

        Assert.IsTrue(Validate.ValidateEntity(user)
            .Any(x => x.MemberNames.Contains("FirstName") && x.ErrorMessage.Contains("First name required.")));
    }

    [Test]
    public void LastNameRequired()
    {
        entity.User user = new()
        {
            FirstName = "Emmanuel",
        };

        Assert.IsTrue(Validate.ValidateEntity(user)
            .Any(x => x.MemberNames.Contains("LastName") && x.ErrorMessage.Contains("Last name required.")));
    }

    [Test]
    public void EmailRequired()
    {
        entity.User user = new()
        {
            LastName = "Allison",
        };

        Assert.IsTrue(Validate.ValidateEntity(user)
            .Any(x => x.MemberNames.Contains("Email") && x.ErrorMessage.Contains("Email required.")));
    }

    [Test]
    public void PasswordHashRequired()
    {
        entity.User user = new()
        {
            LastName = "Allison",
        };

        Assert.IsTrue(Validate.ValidateEntity(user)
            .Any(x => x.MemberNames.Contains("PasswordHash") && x.ErrorMessage.Contains("Password required.")));
    }
}
