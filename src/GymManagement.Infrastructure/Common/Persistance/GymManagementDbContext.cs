using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Common.Persistance;

internal class GymManagementDbContext : DbContext, IUnitOfWork
{
	public DbSet<Subscription> Subscriptions { get; set; }
	public GymManagementDbContext(DbContextOptions<GymManagementDbContext> options) : base(options)
	{

	}
    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}