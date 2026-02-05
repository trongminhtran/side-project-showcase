# Copilot Instructions – Side Project Showcase Platform

You are a coding agent implementing a .NET Clean Architecture backend.

## Absolute Rules
- DO NOT invent business rules
- DO NOT change specifications
- If unclear, STOP

## Architecture
- Domain has no dependencies
- Application depends only on Domain
- Infrastructure depends on Application
- API depends on Application

## Domain Layer Rules
- No EF Core
- No attributes
- Constructors enforce invariants
- Use DomainException for invalid state

## Application Layer Rules
- One command = one use case
- No business logic leakage
- Use repositories via interfaces only

## Infrastructure Rules
- EF Core only
- Fluent API only
- No logic beyond persistence

## Testing Rules
- Domain tests: no mocks
- Application tests: mock repositories
