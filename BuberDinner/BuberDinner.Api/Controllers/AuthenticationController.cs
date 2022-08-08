using Microsoft.AspNetCore.Mvc;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Api.Filters;
using OneOf;
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
        OneOf<AuthenticationResult, DuplicateEmailException> registerResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        return registerResult.Match(
                authResult => Ok(new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token
            )),
            _ => Problem(statusCode: StatusCodes.Status409Conflict,title: "Email already exists !")
        );

        // if(registerResult.IsT0){
        //     var authResult = registerResult.AsT0;
        //     var response = new AuthenticationResponse(
        //     authResult.user.Id,
        //     authResult.user.FirstName,
        //     authResult.user.LastName,
        //     authResult.user.Email,
        //     authResult.Token
        // );
        //     return Ok(response);
        // }

        // return Problem(statusCode: StatusCodes.Status409Conflict,detail: "Email already exists !");
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