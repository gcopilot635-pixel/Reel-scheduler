using ReelSchedulerPro.Shared.DTOs;

namespace ReelSchedulerPro.Application.Services;

public interface IAuthenticationService
{
    Task<AuthTokenDTO> AuthenticateAsync(string email, string password, CancellationToken cancellationToken);
    Task<AuthTokenDTO> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken);
    Task<bool> ValidateTokenAsync(string token, CancellationToken cancellationToken);
}