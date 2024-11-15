namespace AsGuard.Api.Validator.Exceptions;

/// <summary>
/// Represents a base exception for HTTP-related errors, providing a common structure for exceptions that correspond to HTTP response codes.
/// </summary>
public class HttpException : Exception
{
    /// <summary>
    /// Gets the HTTP status code associated with this exception.
    /// </summary>
    /// <remarks>
    /// This status code should correspond to the HTTP response status code that will be returned to the client.
    /// </remarks>
    public int _statusCode { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpException"/> class with a specified error message and HTTP status code.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="statusCode">The HTTP status code associated with this exception.</param>
    /// <remarks>
    /// This constructor is protected to ensure that only derived classes can be instantiated directly.
    /// </remarks>
    protected HttpException(string message, int statusCode) : base(message)
    {
        _statusCode = statusCode;
    }
}