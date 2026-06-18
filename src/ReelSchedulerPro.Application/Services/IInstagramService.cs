using ReelSchedulerPro.Domain.Entities;

namespace ReelSchedulerPro.Application.Services;

public interface IInstagramService
{
    Task<bool> PostReelAsync(InstagramAccount account, ScheduledReel reel, CancellationToken cancellationToken);
    Task<bool> CheckAccountHealthAsync(InstagramAccount account, CancellationToken cancellationToken);
    Task<bool> ValidateAccessTokenAsync(string accessToken, CancellationToken cancellationToken);
}