# Data Model: RSS Feed MVP

## Core Entities

### Subscription

Represents a single feed subscription added by the user.

| Field | Type | Description |
|------|------|-------------|
| Id | string | Unique identifier for the subscription |
| Url | string | The feed URL submitted by the user |
| AddedAt | DateTime | Timestamp when the entry was added |

## Relationships

- A user has a collection of `Subscription` records in the current session.
- Each `Subscription` is independent and does not carry parsed feed item data in the MVP.

## Validation Rules

- `Url` is required.
- `Url` must not be empty or whitespace-only.
- Duplicate `Url` values should be prevented or intentionally ignored.
- No additional metadata is required for the MVP.

## State Model

The MVP state is intentionally simple:

- Empty list
- One or more subscriptions present
- Add operation updates the list immediately
- No persistence or rehydration flow in the MVP
