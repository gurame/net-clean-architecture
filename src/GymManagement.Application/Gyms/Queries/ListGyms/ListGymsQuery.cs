using ErrorOr;
using MediatR;
using GymManagement.Domain.GymAggregate;

namespace GymManagement.Application.Gyms.Queries.ListGyms;

public record ListGymsQuery(Guid SubscriptionId) : IRequest<ErrorOr<List<Gym>>>;