namespace ReelSchedulerPro.Domain.Events;

public class ReelScheduledEvent : DomainEvent
{
    public Guid ReelId { get; set; }
    public Guid OrganizationId { get; set; }
    public DateTime ScheduledFor { get; set; }
}