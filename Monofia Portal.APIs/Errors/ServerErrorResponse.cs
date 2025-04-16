namespace Monofia_Portal.APIs.Errors
{
    public class ServerErrorResponse : ApiResponse
    {
        public string Details { get; set; }
        public ServerErrorResponse(int statusCode, string? errorMessage = null, string? details = null) : base(statusCode, errorMessage)
        {
            Details = details;
        }
    }
}
