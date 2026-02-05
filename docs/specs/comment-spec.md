# Feature Spec – Comment on Project

## Intent
Allow users to comment or reply on a project.

## Preconditions
- Project exists
- Project is public

## Input
- Content
- ParentCommentId (optional)

## Main Flow
1. Validate content
2. Validate parent comment if provided
3. Create comment
4. Persist

## Rules
- Only one level of nesting is allowed

## Failure Cases
- Empty content → 400
- Invalid parent comment → 400
- Project not found → 404
- Project is private → 403
