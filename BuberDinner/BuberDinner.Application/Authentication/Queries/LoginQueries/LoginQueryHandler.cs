// using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Common;
using ErrorOr;
using MediatR;
namespace BuberDinner.Application.Authentication.Queries.LoginQueries;

public class LoginQueryHandler : IRequestHandler<LoginCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository
    ){
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginCommand query, CancellationToken cancellationToken)
    {
        // 1. Check if user exists ?
        if(_userRepository.GetUserByEmail(query.Email) is not User user){
            return Errorss.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is correct ...
        if(user.Password != query.Password){
            return new[] { Errorss.Authentication.InvalidCredentials };
        }

        // 3. Create JWT token ...
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(
            user,
            token
        );
    }
}