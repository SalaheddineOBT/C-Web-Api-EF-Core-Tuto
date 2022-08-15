using Microsoft.AspNetCore.Mvc;
using BuberDinner.Contracts.Authentication;
// using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Errors;
using System.Collections.Generic;
using BuberDinner.Api.Filters;
using FluentResults;
using OneOf;
using ErrorOr;
using MediatR;
namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    // private readonly IAuthenticationService _authenticationService;
    private readonly ISender _mediator;

    // public AuthenticationController(
    //     IAuthenticationService authenticationService,
    //     ISender mediator
    // ){
    //     _authenticationService = authenticationService;
    //     _mediator = mediator;
    // }
    public AuthenticationController(
        ISender mediator
    ){
        _mediator = mediator;
    }

    [HttpPost("register")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var commands = new RegisterCommand(request.FirstName,request.LastName,request.Email,request.Password);
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(commands);
        // ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(
        //     request.FirstName,
        //     request.LastName,
        //     request.Email,
        //     request.Password
        // );

        return registerResult.Match(
            authResult => Ok(new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token
            )),
            err => Problem(err)
        );

        // if(registerResult.IsSuccess){
        //     return Ok(new AuthenticationResponse(
        //         registerResult.Value.user.Id,
        //         registerResult.Value.user.FirstName,
        //         registerResult.Value.user.LastName,
        //         registerResult.Value.user.Email,
        //         registerResult.Value.Token
        //     ));
        // }

        // var error = registerResult.Errors[0];
        // if(error is DuplicateEmailException){
        //     return Problem(
        //         statusCode: StatusCodes.Status409Conflict,
        //         title: error.ToString()
        //     );
        // }
        // return Problem();

        // return registerResult.Match(
        //         authResult => Ok(new AuthenticationResponse(
        //         authResult.user.Id,
        //         authResult.user.FirstName,
        //         authResult.user.LastName,
        //         authResult.user.Email,
        //         authResult.Token
        //     )),
        //     error => Problem(statusCode: (int)error.StatusCode,title: error.ErrorMessage)
        // );

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
    public async Task<IActionResult> Login(LoginRequest request)
    {
    //     var loginResult = _authenticationService.Login(
    //         request.Email,
    //         request.Password
    //     );
        var query = new LoginRequest(
            request.Email,
            request.Password
        );

        ErrorOr<AuthenticationResult>  loginResult = (ErrorOr<AuthenticationResult>) await _mediator.Send(query);

        return loginResult.Match(
            authResult => Ok(new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token
            )),
            err => Problem(err)
        );
        //return Ok(response);
    }

}