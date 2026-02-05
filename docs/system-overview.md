# System Overview – Side Project Showcase Platform

## Purpose
A platform where developers can showcase their side projects and receive feedback via reactions, ratings, and comments.

## Target Users
- Indie developers
- Freelancers
- Small dev teams
- Technical reviewers

## Core Features (MVP)
- Create and manage projects
- React to projects (Like, Love)
- Rate projects (1–5)
- Comment and reply (1-level thread)
- Public / Private project visibility

## Non-Functional Requirements
- Maintainable and modular architecture
- Clear separation of concerns
- Testable domain logic
- Scalable read/write patterns

## Architecture Style
- Clean Architecture
- Modular Monolith
- API-first

## Technology Stack
- Backend: ASP.NET Core (.NET 8+)
- Language: C#
- ORM: Entity Framework Core
- Database: PostgreSQL or SQL Server
- Frontend: React (Vite) + Tailwind CSS

## High-Level Layers
- Domain: Business rules and invariants
- Application: Use cases and orchestration
- Infrastructure: Persistence and integrations
- API: HTTP interface

## Key Assumptions
- Authentication is handled externally (userId is trusted)
- No real-time updates in MVP
- No payment or monetization in MVP
