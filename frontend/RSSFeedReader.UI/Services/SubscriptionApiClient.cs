using System.Net.Http.Json;
using RSSFeedReader.UI.Models;

namespace RSSFeedReader.UI.Services;

public sealed class SubscriptionApiClient(HttpClient httpClient)
{
    public async Task<List<SubscriptionModel>> GetSubscriptionsAsync()
    {
        return await httpClient.GetFromJsonAsync<List<SubscriptionModel>>("subscriptions") ?? [];
    }

    public async Task<SubscriptionModel> AddSubscriptionAsync(string url)
    {
        var response = await httpClient.PostAsJsonAsync("subscriptions", new { url });
        var payload = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException(payload);
        }

        return System.Text.Json.JsonSerializer.Deserialize<SubscriptionModel>(payload)
            ?? throw new InvalidOperationException("Failed to deserialize subscription response.");
    }
}
