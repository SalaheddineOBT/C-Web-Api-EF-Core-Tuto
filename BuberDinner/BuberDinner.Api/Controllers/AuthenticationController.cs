using Microsoft.AspNetCore.Mvc;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Api.Filters;
namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(
        IAuthenticationService authenticationService
    ){
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        
        var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
            request.Email,
            request.Password
        );
        
        var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token
        );

        return Ok(response);
    }
    
}