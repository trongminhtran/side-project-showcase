# Feature Spec – Rate Project

## Intent
Allow users to rate a project from 1 to 5.

## Preconditions
- Project exists
- Project is public

## Input
- Score (1–5)

## Main Flow
1. Validate score
2. Upsert rating for user
3. Recalculate average rating
4. Return current user rating and average

## Failure Cases
- Invalid score → 400
- Project not found → 404
- Project is private → 403
