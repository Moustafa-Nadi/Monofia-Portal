using System.Net;

namespace Monofia_Portal.APIs.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }

        public string? ErrorMessage { get; set; }

        public ApiResponse(int statusCode, string? errorMsg = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMsg ??
                statusCode switch
                {
                    400 => nameof(HttpStatusCode.BadRequest),
                    401 => nameof(HttpStatusCode.Unauthorized),
                    403 => nameof(HttpStatusCode.Forbidden),
                    404 => nameof(HttpStatusCode.NotFound),
                    _ => null
                };
        }
    }
}
