# Side Project Showcase Platform

A platform for developers to showcase their side projects and receive feedback through reactions, ratings, and comments.

---

## Repository Structure

/docs        → Specifications and architectural documents (source of truth)  
/backend     → ASP.NET Core backend  
/frontend    → React frontend  

---

## Core Principles

- Clean Architecture
- Feature-based modularization
- Clear separation of concerns
- Documentation-driven development

---

## Documentation

All system behavior is defined in `/docs`.

Key documents:
- system-overview.md
- architecture.md
- domain-rules.md
- api-contract.md
- decisions.md

All implementations **must follow these documents**.

---

## Backend

- Language: C#
- Framework: ASP.NET Core
- Architecture: Clean Architecture
- Solution file: `/backend/Showcase.sln`

Layers:
- Domain: business rules
- Application: use cases
- Infrastructure: persistence
- API: HTTP layer

---

## Frontend

- Framework: React (Vite)
- Styling: Tailwind CSS
- Structure: feature-based

Frontend consumes backend APIs strictly via documented contracts.

---

## Development Rules

- Do not invent or infer business rules
- Update documentation before changing behavior
- One task = one feature + one layer
- Keep controllers and UI components thin

---

## AI Usage Policy

- Architecture and structure are created manually
- Copilot / Codex is used only for implementation
- AI must not refactor or redesign without explicit instruction

---

## Status

This project is under active development.
