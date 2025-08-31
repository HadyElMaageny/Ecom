namespace Ecom.API.Helper;

public class ApiExceptions : ResponseAPI<ApiExceptions>
{
    public string Details { get; set; }

    public ApiExceptions(int statusCode, string? message = null, ApiExceptions? data = default, string details = null) :
        base(statusCode, message, data)
    {
        Details = details;
    }
}