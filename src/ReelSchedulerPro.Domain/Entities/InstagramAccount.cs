namespace ReelSchedulerPro.Domain.Entities;

/// <summary>
/// Instagram account entity for storing connected Instagram accounts
/// </summary>
public class InstagramAccount
{
    public Guid Id { get; set; }
    public Guid OrganizationId { get; set; }
    public string InstagramId { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty; // Encrypted
    public string? RefreshToken { get; set; } // Encrypted
    public DateTime? TokenExpiresAt { get; set; }
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public int FollowersCount { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsHealthy { get; set; } = true;
    public DateTime? LastHealthCheckAt { get; set; }
    public DateTime ConnectedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Organization Organization { get; set; } = null!;
    public ICollection<ScheduledReel> ScheduledReels { get; set; } = new List<ScheduledReel>();
}
