# Domain Rules

## Aggregate: Project
### Properties
- Id
- OwnerId
- Title
- Description
- Visibility (Public, Private)
- CreatedAt

### Invariants
- Title must not be empty
- OwnerId is immutable
- Visibility must be defined

### Rules
- Private projects cannot receive reactions, ratings, or comments

---

## Aggregate: Reaction
### Properties
- Id
- ProjectId
- UserId
- Type (Like, Love)
- CreatedAt

### Rules
- One reaction per user per project
- Reacting again overwrites the previous reaction

---

## Aggregate: Rating
### Properties
- Id
- ProjectId
- UserId
- Score (1–5)

### Rules
- Score must be between 1 and 5
- One rating per user per project
- User can update their rating

---

## Aggregate: Comment
### Properties
- Id
- ProjectId
- UserId
- Content
- ParentCommentId (nullable)
- CreatedAt

### Rules
- Content must not be empty
- Only one level of reply is allowed
- Parent comment must belong to the same project

---

## Forbidden States
- Reacting to private projects
- Rating outside range 1–5
- Comment with empty content
- Interacting with non-existent project
