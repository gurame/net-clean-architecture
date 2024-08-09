using GymManagement.Domain.Common;
using GymManagement.Infrastructure.Common.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace GymManagement.Infrastructure.Common.Middleware;

public class EventualConsistencyMiddleware(RequestDelegate next)
{
	private readonly RequestDelegate _next = next;
	public async Task InvokeAsync(HttpContext context, IPublisher publisher, GymManagementDbContext dbContext)
	{
		var transaction = await dbContext.Database.BeginTransactionAsync();
		context.Response.OnCompleted(async() => {
			try
			{
				if (context.Items.TryGetValue("DomainEventsQueue", out var value) && 
					value is Queue<IDomainEvent> domainEventsQueue)
					{
						while(domainEventsQueue!.TryDequeue(out var domainEvent))
						{
							await publisher.Publish(domainEvent);
						}
					}
			
				await transaction.CommitAsync();
			}
			catch (Exception ex)
			{
				// notity the user that even though they got a good response, the operation was not successful
			}
			finally
			{
				await transaction.DisposeAsync();
			}
		});
		await _next(context);
	}	
}