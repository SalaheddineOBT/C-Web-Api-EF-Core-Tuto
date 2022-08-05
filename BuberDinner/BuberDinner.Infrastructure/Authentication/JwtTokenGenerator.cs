using BuberDinner.Application.Common.Interfaces.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BuberDinner.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public readonly JwtSettings _jwtSettings;
    public readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(
        IDateTimeProvider dateTimeProvider,
        IOptions<JwtSettings> jwtOptions
    ){
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryTimeInMinutes),
            claims : claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);

    }

}