using MediatR;
using ReelSchedulerPro.Application.Commands;
using ReelSchedulerPro.Domain.Entities;

namespace ReelSchedulerPro.Application.Handlers;

public class ScheduleReelCommandHandler : IRequestHandler<ScheduleReelCommand, Guid>
{
    public async Task<Guid> Handle(ScheduleReelCommand request, CancellationToken cancellationToken)
    {
        var reel = new ScheduledReel
        {
            Id = Guid.NewGuid(),
            OrganizationId = request.OrganizationId,
            InstagramAccountId = request.ReelData.InstagramAccountId,
            VideoUrl = request.ReelData.VideoUrl,
            Caption = request.ReelData.Caption,
            Hashtags = request.ReelData.Hashtags,
            ScheduledFor = request.ReelData.ScheduledFor,
            Timezone = request.ReelData.Timezone,
            Status = "Pending"
        };

        // TODO: Save to database
        return await Task.FromResult(reel.Id);
    }
}