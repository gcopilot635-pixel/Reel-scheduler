namespace ReelSchedulerPro.Domain.Entities;

public class InstagramAccount
{
    public Guid Id { get; set; }
    public Guid OrganizationId { get; set; }
    public string InstagramHandle { get; set; } = string.Empty;
    public string InstagramUserId { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public DateTime? TokenExpiresAt { get; set; }
    public bool IsHealthy { get; set; } = true;
    public DateTime LastHealthCheckAt { get; set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}