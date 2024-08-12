using ErrorOr;
using GymManagement.Domain.SubscriptionAggregate;
using MediatR;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscription;

public record GetSubscriptionQuery(Guid SubscriptionId)
    : IRequest<ErrorOr<Subscription>>;