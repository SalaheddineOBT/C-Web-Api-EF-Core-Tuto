using System.Net;
using FluentResults;

namespace BuberDinner.Application.Common.Errors;

// public class DuplicateEmailException: Exception, IServiceException
// {
//     public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
//     public string ErrorMessage => "Email already exists !";
// }

// public record struct DuplicateEmailException();

public class DuplicateEmailException: IError
{
    public List<IError> Raisons => throw new NotImplementedException();
    // public string ErrorMessage => throw new NotImplementedException();
    // public Dictionary<string, object> Metadata => throw new NotImplementedException();
}