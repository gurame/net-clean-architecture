using GymManagement.Domain.AdminAggregate.Events;
using GymManagement.Domain.Common;
using GymManagement.Domain.SubscriptionAggregate;
using Throw;

namespace GymManagement.Domain.AdminAggregate;

public class Admin : AggregateRoot
{
    public Guid UserId { get; }
    public Guid? SubscriptionId { get; private set; } = null;
    public Admin(
        Guid userId,
        Guid? subscriptionId = null,
        Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        UserId = userId;
        SubscriptionId = subscriptionId;
    }
    private Admin() : base(Guid.NewGuid()){ }
    public void SetSubscription(Subscription subscription)
    {
        SubscriptionId.HasValue.Throw().IfTrue();
        SubscriptionId = subscription.Id;
    }
    public void DeleteSubscription(Guid subscriptionId)
    {
        SubscriptionId.ThrowIfNull().IfNotEquals(subscriptionId);
        SubscriptionId = null;
        _domainEvents.Add(new SubscriptionDeletedEvent(subscriptionId));
    }
}