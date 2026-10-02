namespace RSSFeedReader.Api.Models;

public sealed class Subscription
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Url { get; init; } = string.Empty;
    public DateTime AddedAt { get; init; } = DateTime.UtcNow;
}
