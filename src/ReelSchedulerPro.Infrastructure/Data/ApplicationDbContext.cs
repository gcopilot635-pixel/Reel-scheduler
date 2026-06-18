using Microsoft.EntityFrameworkCore;
using ReelSchedulerPro.Domain.Entities;

namespace ReelSchedulerPro.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Organization> Organizations { get; set; } = null!;
    public DbSet<InstagramAccount> InstagramAccounts { get; set; } = null!;
    public DbSet<ScheduledReel> ScheduledReels { get; set; } = null!;
    public DbSet<CaptionHistory> CaptionHistories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure User
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(256);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.Email).IsUnique();
        });

        // Configure Organization
        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(256);
            entity.HasMany(e => e.Users).WithOne().HasForeignKey(u => u.OrganizationId);
        });

        // Configure InstagramAccount
        modelBuilder.Entity<InstagramAccount>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.InstagramHandle).IsRequired().HasMaxLength(100);
        });

        // Configure ScheduledReel
        modelBuilder.Entity<ScheduledReel>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Caption).IsRequired();
            entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
        });
    }
}
