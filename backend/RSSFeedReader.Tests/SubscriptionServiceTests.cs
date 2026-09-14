using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Tests;

public class SubscriptionServiceTests
{
    [Fact]
    public void AddSubscription_StoresValidUrl()
    {
        var store = new SubscriptionStore();
        var service = new SubscriptionService(store);

        var result = service.AddSubscription("https://example.com/feed.xml");

        Assert.NotNull(result);
        Assert.Equal("https://example.com/feed.xml", result.Url);
        Assert.Single(service.GetSubscriptions());
    }

    [Fact]
    public void AddSubscription_RejectsEmptyUrl()
    {
        var store = new SubscriptionStore();
        var service = new SubscriptionService(store);

        var result = service.AddSubscription("   ");

        Assert.Null(result);
        Assert.Empty(service.GetSubscriptions());
    }
}
