# Quickstart: Validate the MVP RSS Reader

## Prerequisites

- Backend application running locally
- Frontend application running locally
- Access to the app in a browser

## Validation steps

1. Open the frontend page for the RSS reader.
2. Enter a valid feed URL in the subscription field.
3. Submit the form.
4. Confirm the new URL appears in the subscription list.
5. Add a second valid URL and confirm both entries remain visible.
6. Attempt to submit a blank value and confirm the app rejects it without adding a broken entry.

## Expected outcomes

- A valid subscription is added immediately.
- The list updates in place without page reload.
- Blank or malformed entries are rejected clearly.
- The app remains focused on subscription management rather than feed content retrieval.
