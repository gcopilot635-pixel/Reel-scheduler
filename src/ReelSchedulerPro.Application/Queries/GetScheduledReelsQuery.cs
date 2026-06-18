using MediatR;
using ReelSchedulerPro.Domain.Entities;

namespace ReelSchedulerPro.Application.Queries;

public class GetScheduledReelsQuery : IRequest<List<ScheduledReel>>
{
    public Guid OrganizationId { get; set; }
}