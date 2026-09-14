using Microsoft.AspNetCore.Mvc;
using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController(SubscriptionService subscriptionService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IReadOnlyList<Subscription>> Get() => Ok(subscriptionService.GetSubscriptions());

    [HttpPost]
    public ActionResult<Subscription> Post([FromBody] SubscriptionRequest request)
    {
        var subscription = subscriptionService.AddSubscription(request.Url);

        if (subscription is null)
        {
            return BadRequest(new { error = "A valid subscription URL is required." });
        }

        return CreatedAtAction(nameof(Get), subscription);
    }
}
