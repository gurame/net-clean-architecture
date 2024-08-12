using ErrorOr;

namespace GymManagement.Domain.SubscriptionAggregate;

public static class SubscriptionErrors
{
    public static readonly Error CannotHaveMoreGymsThanTheSubscriptionAllows = Error.Validation(
        code: "Subscription.CannotHaveMoreGymsThanTheSubscriptionAllows",
        description: "A subscription cannot have more gyms than the subscription allows");
}