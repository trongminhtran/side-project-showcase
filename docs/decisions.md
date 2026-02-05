# Architecture Decision Records (ADR)

This document records key architectural decisions made for the project.

---

## ADR-001: Use Clean Architecture

**Decision**  
The backend follows Clean Architecture principles.

**Rationale**
- Isolates business logic
- Improves testability
- Reduces coupling to frameworks

**Consequences**
- More initial structure
- Clear long-term benefits

---

## ADR-002: Modular Monolith Instead of Microservices

**Decision**  
Implement a modular monolith for the MVP.

**Rationale**
- Lower operational complexity
- Faster development for solo developer
- Avoid premature distribution

**Consequences**
- Requires discipline to maintain boundaries
- Can be split later if needed

---

## ADR-003: Mono-repo for Backend and Frontend

**Decision**  
Use a single repository for backend and frontend.

**Rationale**
- Easier coordination
- Shared documentation
- Atomic commits across layers

**Consequences**
- Requires clear folder boundaries
- Solution file scoped to backend only

---

## ADR-004: Backend Solution Scoped to /backend

**Decision**  
The `.sln` file is placed inside `/backend`.

**Rationale**
- Prevents frontend from polluting .NET tooling
- Keeps IDE and CI focused
- Improves AI context accuracy

---

## ADR-005: Feature-Based Frontend Structure

**Decision**  
Frontend uses feature-based organization.

**Rationale**
- Better scalability
- Reduced coupling
- Easier feature ownership

---

## ADR-006: Docs as Source of Truth

**Decision**  
All business rules and contracts live in `/docs`.

**Rationale**
- Prevents rule drift
- Enables AI-assisted development safely
- Clear contract between layers

**Consequences**
- Docs must be maintained deliberately
- Spec changes require explicit commits

---

## ADR-007: AI-Assisted Development with Guardrails

**Decision**  
Copilot / Codex is used only for implementation, not architecture.

**Rationale**
- AI excels at execution, not decision-making
- Prevents architectural erosion

**Rules**
- Structure is created manually
- AI must follow specs strictly
- AI must not invent behavior
