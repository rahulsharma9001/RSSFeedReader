# Tasks: MVP RSS Reader

**Input**: Design documents from `/specs/001-mvp-rss-reader/`

**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel (different files, no dependencies)
- **[Story]**: Which user story this task belongs to (e.g., US1, US2, US3)
- Include exact file paths in descriptions

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Establish the minimal backend/frontend structure for the MVP RSS reader.

- [x] T001 Create repository structure for the web app in backend/ and frontend/ directories
- [x] T002 [P] Initialize the ASP.NET Core Web API backend project in backend/RSSFeedReader.Api/
- [x] T003 [P] Initialize the Blazor WebAssembly frontend project in frontend/RSSFeedReader.UI/
- [x] T004 [P] Configure backend and frontend local ports and API base URL values per the project plan
- [x] T005 Configure CORS for the frontend origin and document the local development setup in backend/ and frontend/ configuration files

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Build the minimal shared foundation needed before user stories can be implemented.

**⚠️ CRITICAL**: No user story work can begin until this phase is complete.

- [x] T006 Create a shared subscription model in backend/RSSFeedReader.Api/Models/Subscription.cs with fields `id`, `url`, and `createdAt`
- [x] T007 [P] Add an in-memory subscription store in backend/RSSFeedReader.Api/Services/SubscriptionStore.cs for the MVP workflow
- [x] T008 [P] Add startup configuration for dependency injection and application settings in backend/RSSFeedReader.Api/Program.cs
- [x] T009 Create the frontend service layer in frontend/RSSFeedReader.UI/Services/SubscriptionClient.cs to call the backend API
- [x] T010 Create the base page shell and route structure in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor so the app has a dedicated MVP landing view

**Checkpoint**: Foundation ready - user story implementation can now begin in parallel.

---

## Phase 3: User Story 1 - Add a Feed Subscription (Priority: P1) 🎯 MVP

**Goal**: Let a user submit a feed URL and see it appear in the active subscription list.

**Independent Test**: A user can open the app, submit a valid URL, and confirm the list updates immediately without leaving the page.

### Implementation for User Story 1

- [x] T011 [P] [US1] Add the backend create-subscription API contract in backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs for POST /api/subscriptions
- [x] T012 [US1] Implement the subscription creation logic in backend/RSSFeedReader.Api/Services/SubscriptionService.cs so valid URLs are stored in memory and invalid input is rejected
- [x] T013 [P] [US1] Add UI input fields and submit behavior in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor for entering a feed URL
- [x] T014 [US1] Add a client call to POST the subscription to the backend in frontend/RSSFeedReader.UI/Services/SubscriptionClient.cs
- [x] T015 [US1] Update the page state to append a newly added subscription to the current list after a successful response
- [x] T016 [US1] Add user-friendly validation and error handling for empty or malformed submissions in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor and backend/RSSFeedReader.Api/Services/SubscriptionService.cs

**Checkpoint**: At this point, User Story 1 should be fully functional and testable independently.

---

## Phase 4: User Story 2 - Review the Subscription List (Priority: P2)

**Goal**: Make the current list of subscriptions visible and easy to review as the user adds entries.

**Independent Test**: A user can open the page, review the visible list, and confirm that each successful submission remains on the page as expected.

### Implementation for User Story 2

- [x] T017 [P] [US2] Add the backend retrieval endpoint in backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs for GET /api/subscriptions
- [x] T018 [US2] Implement the list retrieval logic in backend/RSSFeedReader.Api/Services/SubscriptionService.cs using the in-memory store
- [x] T019 [P] [US2] Render the subscription list in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor with each item showing the user-supplied URL
- [x] T020 [US2] Ensure list refresh keeps earlier entries visible while new ones are appended without losing state
- [x] T021 [US2] Add a small page-level loading or empty-state message in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor for the no-subscriptions case

**Checkpoint**: At this point, User Stories 1 and 2 should both work independently.

---

## Phase 5: User Story 3 - Reject Unusable Input Gracefully (Priority: P3)

**Goal**: Guard the MVP from empty, malformed, or duplicate input without making the feature more complex than the project requires.

**Independent Test**: A user tries to submit a blank or unusable URL and the system blocks it without creating a broken entry.

### Implementation for User Story 3

- [x] T022 [P] [US3] Add validation guard logic in backend/RSSFeedReader.Api/Services/SubscriptionService.cs for blank values and invalid inputs at the boundary
- [x] T023 [US3] Add duplicate-subscription handling in backend/RSSFeedReader.Api/Services/SubscriptionService.cs if the same URL is submitted multiple times
- [x] T024 [P] [US3] Surface clear user feedback in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor when validation fails
- [x] T025 [US3] Ensure the page keeps the subscription list unchanged after a rejected submission and does not silently add a broken record

**Checkpoint**: All user stories should now be independently functional.

---

## Phase 6: Polish & Cross-Cutting Concerns

**Purpose**: Final quality checks to ensure the MVP remains aligned with the project’s governance and technical constraints.

- [x] T026 [P] Review the implementation for clear separation between frontend and backend responsibilities per the project constitution
- [x] T027 [P] Verify that inputs are handled safely and that empty or malformed submissions are rejected before persistence or rendering
- [x] T028 [P] Run the quickstart validation from specs/001-mvp-rss-reader/quickstart.md and confirm the expected MVP flow works end-to-end
- [x] T029 Review the final feature scope to confirm no feed-fetching, persistence, or polling features were introduced before the MVP is accepted

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies - can start immediately.
- **Foundational (Phase 2)**: Depends on Setup completion and blocks all story work.
- **User Stories (Phase 3+)**: All depend on the Foundational phase.
- **Polish (Phase 6)**: Depends on all desired user stories being complete.

### User Story Dependencies

- **User Story 1 (P1)**: Can start after Foundational and is the primary MVP story.
- **User Story 2 (P2)**: Depends on the list model and backend retrieval API, but should be independently verifiable.
- **User Story 3 (P3)**: Depends on the validation boundary already established by the MVP flow.

### Parallel Opportunities

- Setup tasks T002-T005 can be done in parallel.
- Foundational tasks T007-T010 can be done in parallel once setup is complete.
- Story 1 tasks T011, T013, T014 can be executed in parallel when the shared model and service layer are ready.
- Story 2 tasks T017 and T019 can be executed in parallel.
- Story 3 tasks T022 and T024 can be executed in parallel.
- Final validation tasks T026-T029 can run together after implementation.

---

## Implementation Strategy

### MVP First (User Story 1 Only)

1. Complete Setup.
2. Complete Foundational.
3. Complete User Story 1.
4. Validate the add-subscription flow end-to-end.
5. Stop and review before adding additional complexity.

### Incremental Delivery

1. Add the foundational API and UI base.
2. Deliver User Story 1 as the MVP increment.
3. Add User Story 2 for reviewability and confirmation.
4. Add User Story 3 for input safety and graceful rejection.
5. Finish with cross-cutting quality checks.

---

## Notes

- [P] tasks are parallelizable and target different files or independent workstreams.
- [Story] labels map each task to its user story for traceability.
- This task list keeps the feature intentionally small and aligned with the MVP scope.
- No test tasks were generated because the specification did not explicitly request TDD tasks or test automation for this phase.
