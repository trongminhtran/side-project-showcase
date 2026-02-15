namespace Showcase.Api.Contracts;

public sealed record CommentProjectRequest(string Content, Guid? ParentCommentId);
