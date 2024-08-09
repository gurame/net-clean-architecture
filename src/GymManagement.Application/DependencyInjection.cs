using FluentValidation;
using GymManagement.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace GymManagement.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(x=> {
			x.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
			x.AddOpenBehavior(typeof(ValidationBehavior<,>));
		});

		services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

		return services;
	}
}