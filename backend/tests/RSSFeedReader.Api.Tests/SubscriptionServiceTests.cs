using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Tests;

public class SubscriptionServiceTests
{
    [Fact]
    public void Add_WhenUrlIsValid_AddsSubscriptionToList()
    {
        var service = new SubscriptionService();

        var result = service.Add("https://example.com/feed.xml");

        Assert.NotNull(result);
        Assert.Equal("https://example.com/feed.xml", result.Url);
        Assert.Single(service.GetAll());
    }

    [Fact]
    public void Add_WhenUrlIsBlank_ThrowsArgumentException()
    {
        var service = new SubscriptionService();

        Assert.Throws<ArgumentException>(() => service.Add("   "));
    }

    [Fact]
    public void Add_WhenDuplicateUrlExists_ThrowsArgumentException()
    {
        var service = new SubscriptionService();
        service.Add("https://example.com/feed.xml");

        Assert.Throws<ArgumentException>(() => service.Add("https://example.com/feed.xml"));
    }
}
