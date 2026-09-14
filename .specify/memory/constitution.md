<!--
Sync Impact Report
- Version change: 0.1.0 → 1.0.0
- Modified principles: none → I. Security & Input Safety; II. Maintainability Through Simplicity; III. Test-First Quality Gates; IV. Code Quality & Review Discipline; V. Incremental Delivery & Architecture Fit
- Added sections: Project Constraints; Development Workflow
- Removed sections: none
- Deferred items: TODO(RATIFICATION_DATE): original adoption date not recorded in repo documents.
-->

# RSS Feed Reader Constitution

## Core Principles

### I. Security & Input Safety
All external input from RSS feed URLs, HTTP responses, and user-provided data MUST be treated as untrusted. The project MUST validate inputs at the boundary, reject malformed or unsafe values early, and never execute or render untrusted content without explicit sanitization or encoding. This keeps the application resilient to malformed feeds, injection vectors, and accidental misuse while preserving a small, auditable surface area.

### II. Maintainability Through Simplicity
The RSS Feed Reader MUST prefer the smallest clear design that satisfies the current MVP and the next planned extension. Components, APIs, and data models MUST have a single responsibility, use consistent naming, and avoid speculative abstractions. This reduces onboarding time, preserves readability, and keeps the codebase easy to extend when feed parsing or persistence is introduced.

### III. Test-First Quality Gates
Every behavior that changes user-facing or integration logic MUST be covered by a failing test before implementation. Tests MUST validate the outcome, not the internal implementation details, and the project MUST keep a fast, reliable feedback loop for UI, API, and endpoint contracts. This prevents regressions in subscription management and ensures future feed-related work remains dependable.

### IV. Code Quality & Review Discipline
Code MUST be readable, deterministic, and consistent with the established .NET conventions for the chosen stack. Developers MUST format code before review, avoid silent failure, handle nulls and exceptions explicitly, and document non-obvious decisions. Pull requests MUST verify build health, tests, and the alignment of the change with the project’s current MVP scope. This protects maintainability and reduces debugging cost.

### V. Incremental Delivery & Architecture Fit
The project MUST deliver the MVP in a staged sequence: subscription management first, then feed retrieval and display, then persistence or other enhancements. Architecture decisions MUST remain compatible with ASP.NET Core Web API and Blazor WebAssembly without introducing unnecessary complexity. This keeps the roadmap honest and ensures the solution remains extensible without abandoning the minimal proof-of-concept approach.

## Project Constraints

The RSS Feed Reader is a local, single-user proof-of-concept focused on adding and listing subscriptions. The application MUST remain intentionally small and practical: in-memory storage is acceptable for the MVP, validation is limited to required boundary checks, and feature scope MUST be kept aligned with the documented goals. The technical stack MUST use ASP.NET Core and Blazor for the current architecture, with future enhancements introduced only when the earlier phase is complete and validated.

The project MUST preserve clear separation between backend responsibilities and frontend responsibilities. The backend handles API contracts and data flow; the frontend handles user interaction and presentation. Configuration values for ports, URLs, and CORS origins MUST be explicit and consistent across local environments. No feature or architectural change may bypass this separation without a documented reason and verification.

## Development Workflow

The team MUST validate the MVP in the order of user value: confirm the API accepts and returns subscriptions, confirm the UI renders the updated list, and only then extend the solution. The project MUST cleanly remove template demo pages and routing conflicts before feature work begins, and it MUST verify configuration accuracy before testing the application in the browser. All work MUST be traceable to the documented goals for the product and must not expand the scope beyond the current phase without approval.

Review and release criteria MUST include successful builds, passing tests for changed behavior, and explicit verification that the change fits the current MVP or the approved next phase. When the project moves beyond the MVP, new capabilities MUST be introduced incrementally, with their risks and trade-offs documented before implementation.

## Governance

This constitution governs all project decisions related to scope, architecture, testing, and delivery. It supersedes informal assumptions and project-local shortcuts when the two conflict. Any amendment MUST be recorded in the constitution, accompanied by a rationale tied to the project’s goals, and reviewed for impact on security, maintainability, and quality before approval.

Versioning follows semantic versioning: MAJOR when backward-incompatible principle changes remove or redefine non-negotiable rules, MINOR when new principles or materially expanded guidance are added, and PATCH for clarifications or wording fixes that do not change behavior. Governance compliance is reviewed during pull requests and milestone checks by confirming that changed work matches the constitution, the current phase, and the approved MVP scope. If a rule cannot be applied due to missing evidence or project context, the team MUST document the exception and provide a follow-up action.

**Version**: 1.0.0 | **Ratified**: TODO(RATIFICATION_DATE): original adoption date not recorded in repo documents. | **Last Amended**: 2026-09-14
