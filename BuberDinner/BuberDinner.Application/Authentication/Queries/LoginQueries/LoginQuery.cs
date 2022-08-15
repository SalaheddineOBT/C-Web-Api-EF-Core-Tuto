// using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Authentication.Common;
using MediatR;
using ErrorOr;

namespace BuberDinner.Application.Authentication.Queries.LoginQueries;
public record LoginCommand(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
