namespace SimpleAuth.Domain.Exceptions;

public class InvalidDetailsException: Exception
{
    public InvalidDetailsException(string message) : base(message) { }
}
