namespace Magic.Service.Exceptions;

public class InvalidSecurityKeyException : Exception
{
    public InvalidSecurityKeyException() : base("Security key is not valid")
    {
    }
}