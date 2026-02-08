namespace Showcase.Application.Comments.Commands;

public sealed record CommentProjectCommand(Guid ProjectId, Guid UserId, string Content, Guid? ParentCommentId);
