# Research: MVP RSS Reader

## Decision

The MVP will support only the subscription management workflow: users can add a feed URL and view the current list of subscriptions in memory.

## Rationale

This decision aligns with the feature specification and the project constitution, which both require a minimal and maintainable MVP. The repository documents state that the initial proof of concept is intentionally limited to subscription management and explicitly excludes feed fetching, parsing, and persistence.

## Alternatives considered

- Full feed parsing and display: rejected because it exceeds the MVP scope and adds unnecessary complexity.
- Persistent storage: rejected because the project explicitly calls for in-memory storage during the MVP.
- Background polling or automatic refresh: rejected because the feature scope is add-and-list only.
- Validation-heavy feed checking: rejected because the MVP assumes the user provides valid URLs and the primary concern is list management rather than feed correctness.

## Findings

- The backend should expose a simple API for creating and retrieving subscriptions.
- The frontend should provide a form for entering a URL and a list view for displaying results.
- The in-memory model should be simple and explicit so it remains easy to replace with persistence later.
- Input validation should at minimum reject blank or malformed submissions without expanding into feed-content validation.
