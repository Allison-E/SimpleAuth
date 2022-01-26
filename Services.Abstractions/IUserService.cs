using SimpleAuth.Contracts.Dto;

namespace SimpleAuth.Services.Abstractions;

public interface IUserService
{
    public Task<bool> Add(AddUserRequest user);

    public Task<object> Verify(VerifyUserRequest userDetails);
}
