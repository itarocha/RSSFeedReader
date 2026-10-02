# Tasks: RSS Feed MVP

**Input**: Design documents from `/specs/001-rss-feed-mvp/`

**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story.

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Create the minimal project structure for the local ASP.NET Core + Blazor MVP.

- [ ] T001 Create backend and frontend project structure per implementation plan in backend/RSSFeedReader.Api/ and frontend/RSSFeedReader.UI/
- [ ] T002 Initialize ASP.NET Core Web API and Blazor WebAssembly projects with the required .NET 8 dependencies and launch configuration
- [ ] T003 [P] Align backend/frontend port configuration, CORS rules, and API base URL in backend/RSSFeedReader.Api/Program.cs and frontend/RSSFeedReader.UI/wwwroot/appsettings.json

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core infrastructure that MUST be complete before user story work begins.

- [ ] T004 Remove template demo pages and verify route cleanup in frontend/RSSFeedReader.UI/Pages/ and frontend/RSSFeedReader.UI/Layout/NavMenu.razor
- [ ] T005 [P] Define the in-memory subscription model and validation rules in backend/RSSFeedReader.Api/Models/Subscription.cs
- [ ] T006 [P] Implement the backend subscription service and repository in backend/RSSFeedReader.Api/Services/SubscriptionService.cs
- [ ] T007 [P] Add the frontend subscription client and DTO model in frontend/RSSFeedReader.UI/Services/SubscriptionApiClient.cs and frontend/RSSFeedReader.UI/Models/SubscriptionModel.cs
- [ ] T008 Create the shared MVP service contract and ensure the app can run locally without feed parsing or persistence in backend/RSSFeedReader.Api/Program.cs

**Checkpoint**: Foundation ready - user story implementation can now begin.

---

## Phase 3: User Story 1 - Add a feed subscription (Priority: P1) 🎯 MVP

**Goal**: Allow a user to enter a valid feed URL and add it to the subscription list.

**Independent Test**: Verify that a user can submit a feed URL and see it appear in the subscription list without reloading the page.

### Implementation for User Story 1

- [ ] T009 [P] [US1] Implement the POST /api/subscriptions endpoint in backend/RSSFeedReader.Api/Program.cs or backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs, accepting a URL payload and returning 201 on success
- [ ] T010 [US1] Implement validation and duplicate handling for empty, whitespace-only, and repeated URLs in backend/RSSFeedReader.Api/Services/SubscriptionService.cs ("Url is required" and duplicate entries are handled consistently)
- [ ] T011 [P] [US1] Add the subscription form and submit handler in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor
- [ ] T012 [US1] Wire the page to call the API and refresh the list immediately after a successful add in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor and frontend/RSSFeedReader.UI/Services/SubscriptionApiClient.cs
- [ ] T013 [US1] Validate the end-to-end add flow locally with a valid RSS URL and confirm the list updates in the UI

**Checkpoint**: At this point, User Story 1 should be fully functional and testable independently.

---

## Phase 4: User Story 2 - View the subscription list (Priority: P1)

**Goal**: Show the current collection of subscriptions to the user.

**Independent Test**: Load the app and confirm all current subscriptions are visible in the list after submission.

### Implementation for User Story 2

- [ ] T014 [P] [US2] Implement the GET /api/subscriptions endpoint in backend/RSSFeedReader.Api/Program.cs or backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs
- [ ] T015 [P] [US2] Add the frontend API call to load the list in frontend/RSSFeedReader.UI/Services/SubscriptionApiClient.cs
- [ ] T016 [US2] Render the subscriptions in a simple list in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor, showing at least URL entries and an empty-state message when no subscriptions exist
- [ ] T017 [US2] Ensure the UI refreshes the displayed list after add operations and on initial page load in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor

**Checkpoint**: At this point, User Stories 1 and 2 should both work independently.

---

## Phase 5: User Story 3 - Keep the MVP intentionally narrow (Priority: P2)

**Goal**: Preserve the project scope as a minimal proof-of-concept and defer non-MVP complexity.

**Independent Test**: Review the implementation and confirm feed parsing, persistence, polling, and item display are not required for completion.

### Implementation for User Story 3

- [ ] T018 [P] [US3] Document the MVP boundary and deferred features in StakeholderDocuments/ProjectGoals.md or the feature plan notes, including explicit exclusion of feed fetching, persistence, and polling
- [ ] T019 [US3] Verify no code paths depend on `System.ServiceModel.Syndication`, persistence layers, or background workers for the current milestone in backend/RSSFeedReader.Api/ and frontend/RSSFeedReader.UI/
- [ ] T020 [US3] Confirm the MVP validation guide remains focused on add-subscription + list-display behavior in specs/001-rss-feed-mvp/quickstart.md

**Checkpoint**: The MVP remains intentionally narrow and ready to demonstrate without broader feature work.

---

## Phase 6: Polish & Cross-Cutting Concerns

**Purpose**: Final cleanup and end-to-end validation across the app.

- [ ] T021 [P] Review the app for empty-input handling, duplicate URL behavior, and startup/configuration consistency across backend/RSSFeedReader.Api/ and frontend/RSSFeedReader.UI/
- [ ] T022 [P] Run the quickstart validation flow from specs/001-rss-feed-mvp/quickstart.md and confirm the user can submit a valid feed URL and see it in the list
- [ ] T023 [P] Update any developer notes or configuration guidance required for local execution in StakeholderDocuments/TechStack.md or the feature documentation
- [ ] T024 Final review of the MVP scope, ensuring no production-ready capabilities were introduced before the base flow is validated

---

## Dependencies & Execution Order

### Phase Dependencies
- **Setup (Phase 1)**: No dependencies - can start immediately
- **Foundational (Phase 2)**: Depends on Setup completion - blocks all user stories
- **User Story 1 (Phase 3)**: Depends on Foundational completion
- **User Story 2 (Phase 4)**: Depends on User Story 1 or at least the shared contract and list flow
- **User Story 3 (Phase 5)**: Can proceed after the core user flow is in place, but should remain independent of broader feature work
- **Polish (Phase 6)**: Depends on all user stories and validation steps being complete

### Parallel Opportunities
- Setup tasks T001-T003 can run in parallel.
- Foundational tasks T005-T007 can run in parallel once project scaffolding is done.
- User Story 1 tasks T009 and T011 can run in parallel, while T010 and T012 depend on the API contract and service implementation.
- User Story 2 tasks T014 and T015 can be worked in parallel, followed by T016-T017.
- Final polish tasks T021-T024 can run as a final validation batch.

## Implementation Strategy

### MVP First
1. Complete Setup and Foundational phases.
2. Deliver User Story 1 and User Story 2 as the minimum viable workflow.
3. Validate the basic flow before any additional scope is considered.
4. Keep User Story 3 as a governance and scope-control task rather than a feature expansion.

### Incremental Delivery
1. Start with the backend API surface and in-memory subscription model.
2. Build the UI form and list display around that API.
3. Validate the add-and-list experience end-to-end.
4. Stop once the proof-of-concept is complete and the MVP boundary is confirmed.

### Parallel Team Strategy
- Developer A: setup and backend contracts
- Developer B: frontend form and list rendering
- Developer C: validation, configuration checks, and scope review
