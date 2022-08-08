namespace BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Common.Errors;
using OneOf;

public interface IAuthenticationService
{
    AuthenticationResult Login(string email, string password);
    OneOf<AuthenticationResult, DuplicateEmailException> Register(string firstName, string lastName, string email, string password);
}