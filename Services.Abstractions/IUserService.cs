using SimpleAuth.Contracts.Dto;

namespace SimpleAuth.Services.Abstractions;

public interface IUserService
{
    /// <summary>
    /// Add a user.
    /// </summary>
    /// <param name="user">Ther details of the user to add.</param>
    /// <returns>A <see cref="Task{Boolean}}"/> which is <see langword="true"/> if the process was successful. Otherwise, <see langword="false"/>.</returns>
    /// <exception cref="Domain.Exceptions.PasswordEntryException">
    ///     This is thrown when the input password is not acceptable (less than 8 characters or empty).
    /// </exception>
    public Task<bool> Add(AddUserRequest user);

    /// <summary>
    /// Tries to log the user in with the user's email and password.
    /// </summary>
    /// <param name="userDetails">The user's login details.</param>
    /// <returns>The user's details if successfully logged in.</returns>
    /// <exception cref="SimpleAuth.Domain.Exceptions.InvalidDetailsException">
    ///     When this is returned, either the email or password provided is invalid.
    /// </exception>
    public Task<object> Authenticate(AuthenticateUserRequest userDetails);
}
