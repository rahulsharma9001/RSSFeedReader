# Data Model: MVP RSS Reader

## Core Entity: Subscription

**Purpose**: Represents a user-managed feed source that should appear in the subscription list.

### Fields

- `id`: unique identifier for the subscription entry
- `url`: the feed URL entered by the user
- `createdAt`: timestamp when the subscription was added

### Validation Rules

- `url` MUST be present and not blank
- `url` MUST be treated as a user-supplied external value and validated at the input boundary
- Duplicate values MAY be rejected to keep the list clear and avoid accidental repetition
- The model is intentionally minimal and is not responsible for feed retrieval or content parsing

## Relationships

- One user can have many subscriptions in the list
- The list is a simple in-memory collection during the MVP
- No additional business entities are required at this stage
