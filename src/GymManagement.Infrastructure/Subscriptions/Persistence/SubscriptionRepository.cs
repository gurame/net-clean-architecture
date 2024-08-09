using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionRepository : ISubscriptionRepository
{
	private static readonly List<Subscription> _subscriptions = [];
    public Task AddSubscriptionAsync(Subscription subscription)
    {
        _subscriptions.Add(subscription);
		return Task.CompletedTask;
    }
    public async Task<Subscription?> GetSubscriptionByIdAsync(Guid id)
    {
        return _subscriptions.FirstOrDefault(x => x.Id == id);
    }
}