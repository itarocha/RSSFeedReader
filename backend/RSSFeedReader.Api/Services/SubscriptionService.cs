using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public sealed class SubscriptionService
{
    private readonly List<Subscription> _subscriptions = [];

    public IReadOnlyList<Subscription> GetAll() => _subscriptions.AsReadOnly();

    public Subscription Add(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("URL is required.", nameof(url));
        }

        var normalizedUrl = url.Trim();

        if (_subscriptions.Any(existing => existing.Url.Equals(normalizedUrl, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException("This feed is already subscribed.", nameof(url));
        }

        var subscription = new Subscription
        {
            Url = normalizedUrl,
            AddedAt = DateTime.UtcNow
        };

        _subscriptions.Add(subscription);
        return subscription;
    }
}
