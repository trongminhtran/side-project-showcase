using Showcase.Domain.Common;

namespace Showcase.Domain.Comments;

public class Comment
{
    public Guid Id { get; private set; }
    public Guid ProjectId { get; private set; }
    public Guid UserId { get; private set; }
    public string Content { get; private set; }
    public Guid? ParentCommentId { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public Comment(Guid id, Guid projectId, Guid userId, string content, Guid? parentCommentId, DateTimeOffset createdAt)
    {
        if (projectId == Guid.Empty)
        {
            throw new DomainException("ProjectId must not be empty");
        }

        if (userId == Guid.Empty)
        {
            throw new DomainException("UserId must not be empty");
        }

        if (string.IsNullOrWhiteSpace(content))
        {
            throw new DomainException("Content must not be empty");
        }

        Id = id;
        ProjectId = projectId;
        UserId = userId;
        Content = content;
        ParentCommentId = parentCommentId;
        CreatedAt = createdAt;
    }
}
