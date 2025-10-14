using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Report_System_Backend.exception;

namespace Report_System_Backend.middleware;

[ApiController]
public class GlobalExceptionHandler : ControllerBase
{
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult HandleError()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

        if (context?.Error is EmptyDatabaseFromReports emptyDbEx)
        {
            return NotFound(new { message = emptyDbEx.Message });
        }
        return Problem(detail: context?.Error.Message, statusCode: 500);
    }
}