using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ReelSchedulerPro.Application.Services;
using ReelSchedulerPro.Domain.Entities;
using ReelSchedulerPro.Infrastructure.Data;
using ReelSchedulerPro.Infrastructure.Services;

namespace ReelSchedulerPro.Infrastructure;

/// <summary>
/// Extension methods for dependency injection
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Authentication Services
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IEncryptionService, EncryptionService>();
        
        // Password hasher
        services.AddScoped<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();

        return services;
    }
}
