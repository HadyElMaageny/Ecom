using System.Text.Json;
using Ecom.API.Helper;

namespace Ecom.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _environment;

    public ExceptionMiddleware(RequestDelegate next, IHostEnvironment environment)
    {
        _next = next;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            var response = _environment.IsDevelopment()
                ? new ApiExceptions(StatusCodes.Status500InternalServerError, ex.Message, null, ex.StackTrace)
                : new ApiExceptions(StatusCodes.Status500InternalServerError, ex.Message);
            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}