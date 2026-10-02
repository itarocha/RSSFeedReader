# Subscription API Contract

## `GET /api/subscriptions`

Returns the current list of subscriptions for the active session.

### Response

```json
[
  {
    "id": "1",
    "url": "https://devblogs.microsoft.com/dotnet/feed/",
    "addedAt": "2026-10-02T00:00:00Z"
  }
]
```

## `POST /api/subscriptions`

Creates a new subscription from a submitted feed URL.

### Request body

```json
{
  "url": "https://devblogs.microsoft.com/dotnet/feed/"
}
```

### Success response

```json
{
  "id": "2",
  "url": "https://devblogs.microsoft.com/dotnet/feed/",
  "addedAt": "2026-10-02T00:00:01Z"
}
```

### Error response

```json
{
  "error": "URL is required."
}
```

HTTP status:
- `200 OK` for successful retrieval
- `201 Created` for successful creation
- `400 Bad Request` for invalid or empty input
