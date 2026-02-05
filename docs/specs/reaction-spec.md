# Feature Spec – React to Project

## Intent
Allow users to react (Like/Dislike/Love) to a public project.

## Preconditions
- Project exists
- Project is public

## Input
- ReactionType (Like/Dislike/Love)

## Main Flow
1. Validate project visibility
2. Check existing reaction by user
3. Insert new or update existing reaction
4. Return updated reaction counts

## Failure Cases
- Project not found → 404
- Project is private → 403
