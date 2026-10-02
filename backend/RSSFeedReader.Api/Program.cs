using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<SubscriptionService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5213", "https://localhost:7025")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("BlazorPolicy");

app.MapGet("/api/subscriptions", (SubscriptionService service) => Results.Ok(service.GetAll()));

app.MapPost("/api/subscriptions", (CreateSubscriptionRequest request, SubscriptionService service) =>
{
    try
    {
        var subscription = service.Add(request.Url);
        return Results.Created($"/api/subscriptions/{subscription.Id}", subscription);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.Run();

public record CreateSubscriptionRequest(string Url);
