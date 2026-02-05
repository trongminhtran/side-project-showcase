# Architecture Overview

## Architecture Style
This system follows **Clean Architecture** with a **Modular Monolith** approach.

Primary goals:
- Strong separation of concerns
- Business rules isolated from frameworks
- High testability
- Long-term maintainability

---

## High-Level Structure

The repository is organized as a mono-repo with clear boundaries:

- `/docs`: Specifications and architectural decisions (source of truth)
- `/backend`: ASP.NET Core backend
- `/frontend`: React frontend

---

## Backend Architecture

### Layers

#### 1. Domain
**Responsibility**
- Business rules
- Invariants
- Domain models

**Characteristics**
- No dependencies on any framework
- No persistence concerns
- No infrastructure logic

#### 2. Application
**Responsibility**
- Use cases
- Application workflows
- Orchestration of domain logic

**Characteristics**
- Depends only on Domain
- Uses repository interfaces
- No EF Core or HTTP logic

#### 3. Infrastructure
**Responsibility**
- Persistence (EF Core)
- External integrations

**Characteristics**
- Implements repository interfaces
- Contains EF Core DbContext and mappings
- No business rules

#### 4. API
**Responsibility**
- HTTP endpoints
- Request/response mapping
- Authentication integration

**Characteristics**
- Thin controllers
- No business logic
- Translates HTTP concerns to application commands

---

## Dependency Direction

Dependencies always point **inward**:

API → Application → Domain  
Infrastructure → Application → Domain

The Domain layer has **no outgoing dependencies**.

---

## Modularization Strategy

The system is modularized by **feature**, not by technical layer.

Core features:
- Projects
- Reactions
- Ratings
- Comments

Each feature spans:
- Domain entities
- Application use cases
- Infrastructure persistence
- API endpoints

---

## Frontend Architecture

Frontend uses a **feature-based structure**:

features/
- projects
- reactions
- ratings
- comments

Each feature owns:
- UI components
- API calls
- Hooks
- Type definitions

Shared concerns live in `/shared`.

---

## Integration Between Frontend and Backend

- Communication via REST APIs
- API definitions live in `docs/api-contract.md`
- Frontend types must align with backend DTOs
- No inferred or undocumented behavior

---

## Architectural Constraints

- Business rules must not leak outside Domain
- API layer must remain thin
- Infrastructure must not contain domain logic
- All code must follow documents in `/docs`

---

## Evolution Strategy

This architecture allows:
- Future extraction into microservices
- Independent evolution of frontend and backend
- Safe AI-assisted development
