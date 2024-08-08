namespace GymManagement.Contracts.Subscriptions;
public record CreateSusbcriptionRequest(SubscriptionType SubscriptionType, Guid AdminId);
