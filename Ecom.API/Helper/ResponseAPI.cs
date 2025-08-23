namespace Ecom.API.Helper
{
    public class ResponseAPI<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public ResponseAPI(int statusCode, string? message = null, T? data = default)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
            Data = data;
        }

        private static string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                201 => "Created",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "Unknown Status"
            };
        }

        // Convenience static methods for common responses
        public static ResponseAPI<T> Ok(T? data = default, string? message = null) 
            => new ResponseAPI<T>(200, message, data);

        public static ResponseAPI<T> Created(T? data = default, string? message = null) 
            => new ResponseAPI<T>(201, message, data);

        public static ResponseAPI<T> NotFound(string? message = null) 
            => new ResponseAPI<T>(404, message);

        public static ResponseAPI<T> BadRequest(string? message = null) 
            => new ResponseAPI<T>(400, message);

        public static ResponseAPI<T> Error(string? message = null) 
            => new ResponseAPI<T>(500, message);
    }
}