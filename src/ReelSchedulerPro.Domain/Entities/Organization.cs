namespace ReelSchedulerPro.Domain.Entities;

public class Organization
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SubscriptionPlan { get; set; } = "Free";
    public DateTime? SubscriptionExpiresAt { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public virtual ICollection<User> Users { get; set; } = new List<User>();
    public virtual ICollection<InstagramAccount> InstagramAccounts { get; set; } = new List<InstagramAccount>();
}