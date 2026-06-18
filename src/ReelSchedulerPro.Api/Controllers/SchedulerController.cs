using Microsoft.AspNetCore.Mvc;
using MediatR;
using ReelSchedulerPro.Application.Commands;
using ReelSchedulerPro.Shared.DTOs;

namespace ReelSchedulerPro.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchedulerController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<SchedulerController> _logger;

    public SchedulerController(IMediator mediator, ILogger<SchedulerController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("schedule-reel")]
    public async Task<IActionResult> ScheduleReel([FromBody] CreateScheduledReelDTO request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Scheduling reel for account: {AccountId}", request.InstagramAccountId);
            
            var organizationId = Guid.NewGuid(); // TODO: Get from claims
            var command = new ScheduleReelCommand
            {
                OrganizationId = organizationId,
                ReelData = request
            };

            var reelId = await _mediator.Send(command, cancellationToken);
            return Ok(new { reelId });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to schedule reel");
            return BadRequest("Failed to schedule reel");
        }
    }
}
