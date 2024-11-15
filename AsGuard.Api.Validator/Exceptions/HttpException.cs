namespace AsGuard.Api.Validator.Exceptions;

public class HttpException : Exception
{
    public int _statusCode { get; }

    protected HttpException(string message, int statusCode) : base(message)
    {
        _statusCode = statusCode;
    }
}