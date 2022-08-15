using BuberDinner.Application.Services.Authentication;
using MediatR;
using ErrorOr;

namespace BuberDinner.Application.Authentication.Commands.Register;
public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
