using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Domain.SubscriptionAggregate;
using Tests.Common.TestConstants;

namespace Tests.Common.Subscriptions;

public static class SubscriptionCommandFactory
{
    public static CreateSubscriptionCommand CreateCreateSubscriptionCommand(
        SubscriptionType? subscriptionType = null,
        Guid? adminId = null)
    {
        return new CreateSubscriptionCommand(
            SubscriptionType: subscriptionType ?? Constants.Subscriptions.DefaultSubscriptionType,
            AdminId: adminId ?? Constants.Admin.Id);
    }
}