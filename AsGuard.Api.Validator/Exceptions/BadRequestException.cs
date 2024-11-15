using Microsoft.AspNetCore.Http;

namespace AsGuard.Api.Validator.Exceptions;

/// <summary>
/// Represents an exception that corresponds to an HTTP 400 (Bad Request) response.
/// </summary>
/// <remarks>
/// Use this exception to indicate that the client has sent an invalid request to the server, 
/// such as missing or invalid parameters, or invalid request data.
/// </remarks>
/// <param name="message">The custom error message that explains the reason for the exception.</param>
public class BadRequestException(string message) : HttpException(message, StatusCodes.Status400BadRequest)
{
}
