namespace ReelSchedulerPro.Domain.Entities;

public class ScheduledReel
{
    public Guid Id { get; set; }
    public Guid OrganizationId { get; set; }
    public Guid InstagramAccountId { get; set; }
    public string VideoUrl { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public string? Hashtags { get; set; }
    public DateTime ScheduledFor { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Scheduled, Posted, Failed
    public string? FailureReason { get; set; }
    public int RetryCount { get; set; } = 0;
    public string Timezone { get; set; } = "UTC";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}