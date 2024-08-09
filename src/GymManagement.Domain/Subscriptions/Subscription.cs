namespace GymManagement.Domain.Subscriptions;

public class Subscription
{
	public Guid Id { get; set; }
	public required string SubscriptionType { get; set; }	
}