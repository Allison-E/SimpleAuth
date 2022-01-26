namespace SimpleAuth.Domain.Exceptions;

public class PasswordEntryException: Exception
{
    public PasswordEntryException(string message) : base(message) { }
}
