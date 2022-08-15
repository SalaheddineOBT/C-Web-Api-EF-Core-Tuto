using Microsoft.Extensions.DependencyInjection;
using BuberDinner.Application.Services.Authentication;
using MediatR;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        return services;
    }
}