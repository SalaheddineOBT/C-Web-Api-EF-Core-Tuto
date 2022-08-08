namespace BuberDinner.Application.Services.Authentication;
using OneOf;

public interface IAuthenticationService
{
    OneOf<AuthenticationResult,> Login(string email, string password);
    AuthenticationResult Register(string firstName, string lastName, string email, string password);
}