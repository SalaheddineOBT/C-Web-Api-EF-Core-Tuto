namespace BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Common.Errors;
using OneOf;
using FluentResults;
using ErrorOr;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
    // OneOf<AuthenticationResult, DuplicateEmailException> Register(string firstName, string lastName, string email, string password);
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    // Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}