using ReelSchedulerPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ReelSchedulerPro.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private PeriodicTimer? _timer;

    public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Reel Scheduler Worker started");
        
        _timer = new PeriodicTimer(TimeSpan.FromSeconds(30));

        try
        {
            while (await _timer.WaitForNextTickAsync(stoppingToken))
            {
                await ProcessScheduledReels(stoppingToken);
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("Worker cancellation requested");
        }
        finally
        {
            _timer?.Dispose();
        }
    }

    private async Task ProcessScheduledReels(CancellationToken cancellationToken)
    {
        try
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var now = DateTime.UtcNow;

                var reelsToPost = await dbContext.ScheduledReels
                    .Where(r => r.Status == "Pending" && r.ScheduledFor <= now)
                    .ToListAsync(cancellationToken);

                _logger.LogInformation("Processing {Count} reels", reelsToPost.Count);

                foreach (var reel in reelsToPost)
                {
                    reel.Status = "Scheduled";
                    // TODO: Post to Instagram
                }

                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing scheduled reels");
        }
    }
}
