namespace RSSFeedReader.UI.Models;

public sealed class SubscriptionModel
{
    public string Id { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DateTime AddedAt { get; set; }
}
