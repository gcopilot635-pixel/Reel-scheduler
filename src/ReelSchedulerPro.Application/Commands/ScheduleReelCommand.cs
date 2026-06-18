using MediatR;
using ReelSchedulerPro.Shared.DTOs;

namespace ReelSchedulerPro.Application.Commands;

public class ScheduleReelCommand : IRequest<Guid>
{
    public Guid OrganizationId { get; set; }
    public CreateScheduledReelDTO ReelData { get; set; } = null!;
}