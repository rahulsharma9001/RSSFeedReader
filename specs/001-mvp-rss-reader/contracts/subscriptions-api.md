# Subscription API Contract

## Overview

This contract describes the minimal API needed to support the MVP subscription workflow.

## Endpoints

### POST /api/subscriptions

**Purpose**: Add a new feed subscription.

**Request body**:

```json
{
  "url": "https://example.com/feed.xml"
}
```

**Behavior**:

- Accepts a provided feed URL from the client
- Rejects blank or unusable input
- Adds the subscription to the in-memory list when valid

**Success response**:

```json
{
  "id": 1,
  "url": "https://example.com/feed.xml",
  "createdAt": "2026-09-14T00:00:00Z"
}
```

**Error response**:

```json
{
  "error": "A valid subscription URL is required."
}
```

### GET /api/subscriptions

**Purpose**: Retrieve the current list of subscriptions.

**Success response**:

```json
[
  {
    "id": 1,
    "url": "https://example.com/feed.xml",
    "createdAt": "2026-09-14T00:00:00Z"
  }
]
```

## Notes

- This contract intentionally excludes feed parsing, refresh operations, and persistence.
- The contract is limited to the MVP responsibilities defined by the feature specification and project constitution.
