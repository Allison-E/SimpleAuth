using dtos = SimpleAuth.Contracts.Dto;
using System.Linq;
using NUnit.Framework;
using System;

namespace SimpleAuth.UnitTests.Contracts.Dto;

internal class AddUserRequest
{
    [Test]
    public void FirstNameRequired()
    {
        dtos.AddUserRequest user = new()
        {
            LastName = "Allison",
        };

        Assert.IsTrue(Validate.ValidateEntity(user)
            .Any(x => x.MemberNames.Contains("FirstName") && x.ErrorMessage.Contains("First name required")));
    }

    [Test]
    public void LastNameRequired()
    {
        dtos.AddUserRequest user = new()
        {
            FirstName = "Emmanuel",
        };

        Assert.IsTrue(Validate.ValidateEntity(user)
            .Any(x => x.MemberNames.Contains("LastName") && x.ErrorMessage.Contains("Last name required")));
    }

    [Test]
    public void EmailRequired()
    {
        dtos.AddUserRequest user = new()
        {
            LastName = "Allison",
        };

        Assert.IsTrue(Validate.ValidateEntity(user)
            .Any(x => x.MemberNames.Contains("Email") && x.ErrorMessage.Contains("Email required")));
    }

    [TestCase("eeeegmail.com")]
    [TestCase("eiw@gmaill.")]
    [TestCase("ekjf@Fffcom")]
    public void EmailInvalid(string emailAddress)
    {
        dtos.AddUserRequest user = new()
        {
            LastName = "Allison",
            Email = emailAddress,
        };

        Assert.IsTrue(Validate.ValidateEntity(user)
            .Any(x => x.MemberNames.Contains("Email") && x.ErrorMessage.Contains("Please put in a valid email")));
    }

    [Test]
    public void PasswordRequired()
    {
        dtos.AddUserRequest user = new()
        {
            LastName = "Allison",
        };

        Assert.IsTrue(Validate.ValidateEntity(user)
            .Any(x => x.MemberNames.Contains("Password") && x.ErrorMessage.Contains("Password required")));
    }

    [Test]
    public void GenderDefaultIsPreferNotToSay()
    {
        dtos.AddUserRequest user = new()
        {
            LastName = "Allison",
        };

        Console.WriteLine(user.Gender);
        Assert.IsTrue(user.Gender == Domain.Enums.Gender.PreferNotToSay);
    }
}
