using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public class SubscriptionStore
{
    private readonly List<Subscription> _subscriptions = [];

    public IReadOnlyList<Subscription> GetAll() => _subscriptions.AsReadOnly();

    public void Add(Subscription subscription) => _subscriptions.Add(subscription);
}
