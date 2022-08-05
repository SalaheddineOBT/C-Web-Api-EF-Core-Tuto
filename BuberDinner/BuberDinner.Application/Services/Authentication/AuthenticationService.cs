using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository
    ){
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Check if user exists ?

        if(_userRepository.GetUserByEmail(email) is not User user){
            throw new Exception("No User with given email !");
        }

        // 2. Validate the password is correct ...

        if(user.Password != password){
            throw new Exception("Invalid Password !");
        }

        // 3. Create JWT token ...

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        
        // 1. Check if user already exists ?

        if(_userRepository.GetUserByEmail(email) is not null){
            throw new Exception("User with given email already exists !");
        }

        // 2. Create user (generate unique ID) ,

        var user = new User{
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // 3. Create JWT token ...

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }

}