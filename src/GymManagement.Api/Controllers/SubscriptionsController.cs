using GymManagement.Application.Subscriptions.Commands;
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

    public async Task<IActionResult> Create(CreateSusbcriptionRequest request)
	{
        var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(), request.AdminId);
        var result = await _mediator.Send(command);
        return result.Match(
            success => Ok(new SubscriptionResponse(result.Value, request.SubscriptionType)),
            error => Problem()
        );
	}
}