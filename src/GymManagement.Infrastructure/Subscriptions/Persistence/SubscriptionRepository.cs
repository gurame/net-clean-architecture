using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using GymManagement.Infrastructure.Common.Persistance;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

internal class SubscriptionRepository : ISubscriptionRepository
{
	private readonly GymManagementDbContext _context;
    public SubscriptionRepository(GymManagementDbContext context)
    {
        _context = context;
    }
    public async Task AddSubscriptionAsync(Subscription subscription)
    {
        await _context.Subscriptions.AddAsync(subscription);
    }
    public async Task<Subscription?> GetSubscriptionByIdAsync(Guid id)
    {
        return await _context.Subscriptions.FindAsync(id);
    }
}