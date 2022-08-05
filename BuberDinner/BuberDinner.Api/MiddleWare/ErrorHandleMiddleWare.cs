using System.Net;
using System.Text.Json;

namespace BuberDinner.Api.MiddleWare;

public class ErrorHandleMiddleWare
{
    private readonly RequestDelegate _next;

    public ErrorHandleMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context){
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            await HandleExceptionAsync(context,ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context,Exception ex){
        var code = HttpStatusCode.InternalServerError; //// 500 if unexpected
        var result = JsonSerializer.Serialize(new { error = "An error occurred while processing your request ! " + ex.Message});
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }

}