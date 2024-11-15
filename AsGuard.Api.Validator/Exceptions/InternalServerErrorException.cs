using Microsoft.AspNetCore.Http;

namespace AsGuard.Api.Validator.Exceptions;

/// <summary>
/// Represents an exception that corresponds to an HTTP 500 (Internal Server Error) response.
/// </summary>
/// <remarks>
/// Use this exception to indicate that an unexpected server-side error has occurred, 
/// preventing the successful processing of the client's request.
/// </remarks>
/// <param name="message">The custom error message that explains the reason for the exception.</param>
public class InternalServerErrorException(string message) : HttpException(message, StatusCodes.Status500InternalServerError)
{
}
