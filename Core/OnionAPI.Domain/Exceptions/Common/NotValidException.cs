namespace OnionAPI.Domain.Exceptions.Common;

public class NotValidException : Exception, IBaseException
{
    public string ErrorMessage { get; }

    public int StatusCode { get; }

    public NotValidException(string message, int statusCode)
    {
        ErrorMessage = message;
        StatusCode = statusCode;
    }
}

