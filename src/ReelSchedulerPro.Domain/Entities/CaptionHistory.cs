namespace ReelSchedulerPro.Domain.Entities;

public class CaptionHistory
{
    public Guid Id { get; set; }
    public Guid OrganizationId { get; set; }
    public string Prompt { get; set; } = string.Empty;
    public string GeneratedCaption { get; set; } = string.Empty;
    public string? Hashtags { get; set; }
    public string AiModel { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}