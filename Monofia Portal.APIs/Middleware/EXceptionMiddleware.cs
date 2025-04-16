using Monofia_Portal.APIs.Errors;
using Serilog;
using System.Net;

namespace Monofia_Portal.APIs.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unhandled exception occurred!");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                  ? new ServerErrorResponse(
                      (int)HttpStatusCode.InternalServerError,
                      ex.Message,
                      ex.StackTrace!.ToString())
                  : new ServerErrorResponse((int)HttpStatusCode.InternalServerError);

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }

}
