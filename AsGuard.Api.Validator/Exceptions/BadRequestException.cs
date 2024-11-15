using Microsoft.AspNetCore.Http;

namespace AsGuard.Api.Validator.Exceptions;

public class BadRequestException : HttpException
{
    public BadRequestException(string message) : base(message, StatusCodes.Status400BadRequest)
    {
    }
}
