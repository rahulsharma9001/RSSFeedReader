using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public class SubscriptionService(SubscriptionStore store)
{
    public Subscription? AddSubscription(string? url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return null;
        }

        var trimmedUrl = url.Trim();

        if (!Uri.TryCreate(trimmedUrl, UriKind.Absolute, out var uri) ||
            (!uri.Scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) &&
             !uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)))
        {
            return null;
        }

        var existing = store.GetAll().FirstOrDefault(item =>
            string.Equals(item.Url, uri.ToString(), StringComparison.OrdinalIgnoreCase));

        if (existing is not null)
        {
            return null;
        }

        var subscription = new Subscription
        {
            Id = store.GetAll().Count + 1,
            Url = uri.ToString(),
            CreatedAt = DateTime.UtcNow
        };

        store.Add(subscription);
        return subscription;
    }

    public IReadOnlyList<Subscription> GetSubscriptions() => store.GetAll();
}
