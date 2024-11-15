using Microsoft.AspNetCore.Http;

namespace AsGuard.Api.Validator.Exceptions;

/// <summary>
/// Represents an exception that corresponds to an HTTP 404 (Not Found) response.
/// </summary>
/// <remarks>
/// Use this exception to indicate that a requested resource could not be found, 
/// either because it does not exist or the client does not have access to it.
/// </remarks>
/// <param name="message">The custom error message that explains the reason for the exception.</param>
public class NotFoundException(string message) : HttpException(message, StatusCodes.Status404NotFound)
{
}
