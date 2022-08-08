using Microsoft.Extensions.DependencyInjection;
using BuberDinner.Application.Common.Interfaces.Authentication;
using Microsoft.Extensions.Configuration;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using BuberDinner.Application.Common.Services;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Application.Common.Interfaces.Persistence;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration
    ){
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider,DateTimeProvider>();

        services.AddScoped<IUserRepository,UserRepository>();

        return services;
    }
}