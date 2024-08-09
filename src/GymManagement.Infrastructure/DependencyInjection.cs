using GymManagement.Application.Common.Interfaces;
using GymManagement.Infrastructure.Common.Persistance;
using GymManagement.Infrastructure.Subscriptions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddDbContext<GymManagementDbContext>(options=>{
			options.UseSqlite("Data Source = GymManagement.db");
		});
		services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<GymManagementDbContext>());

		services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
		
		return services;
	}
}