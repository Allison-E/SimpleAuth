using SimpleAuth.Contracts.Dto;
using SimpleAuth.Services.Abstractions;
using SimpleAuth.Persistence;
using SimpleAuth.Domain.Entities;
using SimpleAuth.Domain.Exceptions;

namespace SimpleAuth.Services;

public class UserService : IUserService
{
    private IUserContext context;

    public UserService(IUserContext context) => this.context = context;

    public async Task<bool> Register(AddUserRequest user)
    {
        // Does this account already exist?
        var existingAcc = context.Users.Where(x => x.Email == user.Email).CountAsync();
        string passwordHash;

        try
        {
            checkPassword(user.Password);
            passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
        }
        catch (PasswordEntryException e)
        {
            throw e;
        }

        await existingAcc;
        if (existingAcc.Result == 0)
        {
            await context.Users.AddAsync(new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = passwordHash,
                Gender = user.Gender,
            });
        }
        else
            throw new AccountExistsException($"An account with the email {user.Email} already exists.");

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<object> Login(LoginUserRequest userDetails)
    {
        string invalidMessage = "Email or password is incorrect.";

        var user = await context.Users.Where(x => x.Email == userDetails.Email).FirstOrDefaultAsync();

        if (user == null) throw new InvalidDetailsException(invalidMessage);

        if (BCrypt.Net.BCrypt.Verify(userDetails.Password, user.PasswordHash))
        {
            return new UserResponse()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                JoinedAt = user.JoinedAt,
            };
        }
        else
            throw new InvalidDetailsException(invalidMessage);
    }

    private void checkPassword(string password)
    {
        if (password is null or "")
            throw new PasswordEntryException("Password is required. Please put in a password.");
        if (password.Length < 8)
        {
            throw new PasswordEntryException("Password should be more than 8 characters long.");
        }
    }
}
