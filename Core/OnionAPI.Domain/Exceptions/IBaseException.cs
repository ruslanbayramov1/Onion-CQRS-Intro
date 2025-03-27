namespace OnionAPI.Domain.Exceptions;

public interface IBaseException
{
    public string ErrorMessage { get; } 
    public int StatusCode { get; } 
}
