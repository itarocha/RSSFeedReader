# Quickstart: RSS Feed MVP

## Prerequisites

- .NET SDK 8 or newer
- A local terminal with access to the repository

## Recommended validation flow

1. Start the backend API from the repository root:
   - `dotnet run --project backend/RSSFeedReader.Api`
2. Start the frontend app:
   - `dotnet run --project frontend/RSSFeedReader.UI`
3. Open the frontend in a browser.
4. Enter a valid feed URL such as `https://devblogs.microsoft.com/dotnet/feed/`.
5. Submit the form.
6. Confirm the feed appears in the subscription list.

## Expected result

The app should show the entered feed in the list without requiring feed parsing, item display, or persistence.

## Exit criteria

The requirement is satisfied when:

- the user can submit a URL,
- the created subscription is visible in the UI,
- the application remains within the MVP scope and does not require additional feed-processing features.
