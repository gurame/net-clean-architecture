using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{
	public IActionResult Create(CreateSusbcriptionRequest request)
	{
		return Ok(request);
	}
}