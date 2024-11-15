using AsGuard.Api.Validator.Exceptions;
using Microsoft.AspNetCore.Http;

namespace AsGuard.Api.Validator.Middelware;

public class GuardMiddleware
{
    private readonly RequestDelegate _next;

    public GuardMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (HttpException ex)
        {
            context.Response.StatusCode = ex._statusCode;
            await context.Response.WriteAsync($"Validation failed: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Generic exception handling
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync($"An unexpected error occurred: {ex.Message}");
        }
    }
}
