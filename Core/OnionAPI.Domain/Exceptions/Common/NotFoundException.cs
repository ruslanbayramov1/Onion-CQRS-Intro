using Microsoft.AspNetCore.Http;
using OnionAPI.Domain.Entities.Common;

namespace OnionAPI.Domain.Exceptions.Common;

public class NotFoundException<T> : Exception, IBaseException where T : BaseEntity
{
    public string ErrorMessage { get; }

    public int StatusCode => StatusCodes.Status404NotFound;

    public NotFoundException()
    {
        ErrorMessage = $"{typeof(T).Name} is not found";
    }
}

public class NotFoundException : Exception, IBaseException
{
    public string ErrorMessage { get; }

    public int StatusCode => StatusCodes.Status404NotFound;

    public NotFoundException(string key)
    {
        ErrorMessage = $"{key} is not found";
    }
}

