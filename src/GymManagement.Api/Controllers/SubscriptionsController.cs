using GymManagement.Application.Subscriptions.Commands;
using GymManagement.Application.Subscriptions.Queries;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{
	private readonly ISender _mediator;
    public SubscriptionsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSusbcriptionRequest request)
	{
        var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(), request.AdminId);
        var result = await _mediator.Send(command);
        return result.Match(
            subscription => Ok(new SubscriptionResponse(subscription.Id, request.SubscriptionType)),
            error => Problem()
        );
	}

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
	{
        var query = new GetSubscriptionQuery(id);
        var result = await _mediator.Send(query);
        return result.Match(
            subscription => Ok(new SubscriptionResponse(
                subscription.Id, 
                Enum.Parse<SubscriptionType>(subscription.SubscriptionType))),
            error => Problem()
        );
	}
}