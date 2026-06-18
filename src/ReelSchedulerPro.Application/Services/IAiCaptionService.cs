namespace ReelSchedulerPro.Application.Services;

public interface IAiCaptionService
{
    Task<string> GenerateCaptionAsync(string prompt, CancellationToken cancellationToken);
    Task<string> GenerateHashtagsAsync(string caption, CancellationToken cancellationToken);
    Task<string> GenerateHookAsync(string topic, CancellationToken cancellationToken);
}