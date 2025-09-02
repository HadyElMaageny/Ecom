using System.Text.Json;
using Ecom.API.Helper;
using Microsoft.Extensions.Caching.Memory;

namespace Ecom.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _environment;
    private readonly IMemoryCache _memoryCache;
    private readonly TimeSpan _rateLimitWindow = TimeSpan.FromSeconds(30);

    public ExceptionMiddleware(RequestDelegate next, IHostEnvironment environment, IMemoryCache memoryCache)
    {
        _next = next;
        _environment = environment;
        _memoryCache = memoryCache;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            ApplySecurity(context);
            if (IsRequestAllowed(context) == false)
            {
                context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                context.Response.ContentType = "application/json";
                var response = new ApiExceptions(StatusCodes.Status429TooManyRequests,
                    "Too many requests. Please try again later");
                var jsonResponse = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonResponse);
            }

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

    private class RateEntry
    {
        public DateTime Timestamp { get; set; }
        public int Count { get; set; }
    }

    public bool IsRequestAllowed(HttpContext context)
    {
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var cacheKey = $"Rate:{ip}";
        var now = DateTime.UtcNow;


        // Try get or create the RateEntry
        var entry = _memoryCache.GetOrCreate(cacheKey, e =>
        {
            e.AbsoluteExpirationRelativeToNow = _rateLimitWindow;
            return new RateEntry { Timestamp = now, Count = 1 }; // first request for this window
        });

        // If the factory created the entry it already counts as 1 and is allowed
        if (entry?.Timestamp.Add(_rateLimitWindow) > now)
        {
            // inside same window
            if (entry.Count >= 8) return false; // deny
            entry.Count++; // increment
            _memoryCache.Set(cacheKey, entry, _rateLimitWindow); // store updated entry
            return true;
        }
        else
        {
            // window expired: reset to new window starting now
            var newEntry = new RateEntry { Timestamp = now, Count = 1 };
            _memoryCache.Set(cacheKey, newEntry, _rateLimitWindow);
            return true;
        }
    }

    private void ApplySecurity(HttpContext context)
    {
        context.Response.Headers["X-Content-Type-Options"] = "nosniff";
        context.Response.Headers["X-XSS-Protection"] = "1; mode=block";
        context.Response.Headers["X-Frame-Options"] = "Deny";
    }
}