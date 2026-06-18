namespace ReelSchedulerPro.Domain.Events;

public abstract class DomainEvent
{
    public DateTime OccurredOn { get; private set; } = DateTime.UtcNow;
}