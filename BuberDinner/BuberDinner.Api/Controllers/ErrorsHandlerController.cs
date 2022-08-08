using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using BuberDinner.Application.Common.Errors;

namespace BuberDinner.Api.Controllers;

public class ErrorsHandlerController : ControllerBase
{
    [Route("error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            // DuplicateWaitObjectException => (StatusCodes.Status409Conflict, "Email already exists ."),
            // _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred ."),
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred ."),
        };

        return Problem(detail: "" + message,statusCode: statusCode);
    }
}