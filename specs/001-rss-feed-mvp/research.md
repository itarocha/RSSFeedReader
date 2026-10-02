# Research: RSS Feed MVP

## Decision

The MVP will implement a single-user RSS/Atom subscription manager using an ASP.NET Core Web API and Blazor WebAssembly app with in-memory subscription storage.

## Rationale

- The stakeholder documents state that the MVP is intentionally simple and focused on subscription management.
- The technology stack is already chosen as ASP.NET Core Web API + Blazor WebAssembly.
- The project goals explicitly allow in-memory storage and exclude feed fetching and parsing from the MVP scope.

## Alternatives considered

1. Full RSS feed fetching and item display
   - Rejected because it exceeds the MVP definition and would add parsing, networking, and presentation complexity before the core workflow is proven.

2. Database-backed persistence in the first phase
   - Rejected because the project goals say memory-only storage is acceptable for the MVP and the feature is a local prototype.

3. Background polling or scheduled refresh
   - Rejected because the project intentionally scopes the first phase to manual subscription entry and list display.

## Resolved assumptions

- The app is local-only and single-user.
- Feed URLs are assumed to be valid enough for the prototype and are only minimally checked.
- Duplicate feed URLs are treated as a non-critical edge case and handled consistently in implementation.
- No article parsing or storage of feed items is required for milestone completion.
