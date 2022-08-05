using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace BuberDinner.Api.Controllers;

public class ErrorsHandlerController : ControllerBase
{
    [Route("error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem(detail: "" + exception?.Message);

    }
}