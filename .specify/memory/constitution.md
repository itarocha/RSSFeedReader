<!--
Sync Impact Report
- Version: 0.1.0 → 1.0.0
- Modified principles: N/A (initial constitution)
- Added sections: Core Principles, Project Constraints, Development Workflow
- Removed sections: placeholder template content
- Follow-up TODOs: none
-->

# RSS Feed Reader Constitution

## Core Principles

### I. Purpose-Driven MVP
The project exists to validate simple RSS subscription management in a minimal ASP.NET Core + Blazor application. Every feature and code change must serve the MVP goal of adding a feed URL and displaying the resulting subscription list. We will not broaden scope into feed parsing, persistence, or polished UI unless the minimal working requirement is complete and accepted.

### II. Security-First External Data Handling
All code that touches external network input, feed content, URLs, or user-provided data must treat that data as untrusted. Validate inputs at the boundary, avoid unsafe HTML rendering, and prefer explicit parsing and safe defaults. The project must not introduce dangerous behavior such as arbitrary URL execution, unescaped content injection, or accepting untrusted data without a clear handling strategy.

### III. Maintainable Architecture and Separation of Concerns
Backend and frontend responsibilities must stay clearly separated. The API owns request handling and business logic for subscriptions; the UI owns interaction and display; shared concerns must remain minimal and documented. We will favor simple, readable C# types and small, well-named components over clever abstractions that are harder to maintain.

### IV. Code Quality and Reviewable Delivery
All implementation work must be readable, testable, and consistent with the technology stack. Use clear naming, narrow scope, and small, reviewable commits. New features must be easy for another developer to understand without requiring hidden project knowledge. If a change adds complexity, it must be justified by a project requirement or a clear technical necessity.

### V. Testability and Verification Before Completion
Features are not considered complete until they are checked against the relevant behavior. For the MVP, this means verifying the UI can add a subscription and the list updates correctly, and validating the backend and frontend still run without configuration or routing errors. Automated tests are required for logic that is risk-prone or likely to regress; manual verification is required for UI and integration flows.

## Project Constraints
The project is intentionally minimal and intentionally scoped for a local proof-of-concept. The application may use in-memory storage for the MVP; it must not assume future production requirements are in place without explicit follow-up work. The technology choices in ASP.NET Core and Blazor must support future extension without forcing a rewrite, but the current implementation must stay lean and avoid unneeded dependencies.

## Development Workflow
1. Start from the MVP requirement and verify scope before implementation.
2. Keep feature work aligned with the project stack and avoid unnecessary architecture churn.
3. Confirm configuration consistency before testing: backend port, frontend base URL, and CORS settings must agree.
4. Validate routing and startup behavior before UI work proceeds, especially after project scaffolding or template cleanup.
5. Document and defer non-MVP capabilities such as persistence, polling, and richer feed handling until the core subscription flow is proven.

## Governance
This constitution governs all project decisions related to architecture, quality, and scope. Any change to project principles, required behaviors, or delivery standards must be documented in the constitution with clear rationale and a version update. The project must prioritize security, maintainability, and code quality over speed alone, and any deviation from this document requires explicit review and justification.

All work must be checked against the governing principles before completion. If a change broadens scope beyond the MVP, it must be explicitly justified, named as a deferred enhancement, and tracked separately from the base requirement. Complexity, configuration drift, and undocumented shortcuts are not acceptable without review.

**Version**: 1.0.0 | **Ratified**: 2026-10-02 | **Last Amended**: 2026-10-02
