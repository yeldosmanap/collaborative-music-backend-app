namespace CollaborativeMusicApp.Application.Exceptions;

public class UserAlreadyExistsByEmailException : Exception
{
    public UserAlreadyExistsByEmailException()
    {
    }

    public UserAlreadyExistsByEmailException(string? message) : base(message)
    {
    }

    public UserAlreadyExistsByEmailException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}