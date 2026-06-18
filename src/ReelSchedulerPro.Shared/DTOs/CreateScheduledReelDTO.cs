namespace ReelSchedulerPro.Shared.DTOs;

public class CreateScheduledReelDTO
{
    public Guid InstagramAccountId { get; set; }
    public string VideoUrl { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public string? Hashtags { get; set; }
    public DateTime ScheduledFor { get; set; }
    public string Timezone { get; set; } = "UTC";
}