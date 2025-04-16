using Microsoft.AspNetCore.Mvc;
using Monofia_Portal.APIs.Errors;

namespace Monofia_Portal.APIs.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public ActionResult GetNotFoundEndPoint(int code)
        {
            return NotFound(new ApiResponse(code));
        }
    }
}
