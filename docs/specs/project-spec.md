# Feature Spec – Create Project

## Intent
Allow a user to create a side project for showcasing.

## Preconditions
- User is authenticated
- UserId is available

## Input
- Title
- Description
- Visibility

## Main Flow
1. Validate title
2. Create Project aggregate
3. Persist project
4. Return ProjectId

## Validation Rules
- Title must not be empty

## Failure Cases
- Validation error → 400
- Unauthorized → 401
