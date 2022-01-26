namespace SimpleAuth.Domain.Exceptions;

public class AccountExistsException: Exception
{
    public AccountExistsException(string message) : base(message) { }
}
