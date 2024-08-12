using GymManagement.Domain.Common;
namespace GymManagement.Domain.AdminAggregate.Events;
public record SubscriptionDeletedEvent(Guid SubscriptionId) : IDomainEvent;