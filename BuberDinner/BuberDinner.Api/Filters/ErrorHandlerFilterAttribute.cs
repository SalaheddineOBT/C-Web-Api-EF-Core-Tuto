using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Filters;
public class ErrorHandlerFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var ex = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Title = "An error occurred while processing your request !",
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = "" + ex.Message
        };

        if(ex is null){ return; }

        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
    }
}