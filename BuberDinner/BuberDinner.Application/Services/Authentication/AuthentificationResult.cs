using BuberDinner.Domain.Entities;
namespace BuberDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string Token
);