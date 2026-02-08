using Showcase.Domain.Common;

namespace Showcase.Domain.Reactions;

public class Reaction
{
    public Guid Id { get; private set; }
    public Guid ProjectId { get; private set; }
    public Guid UserId { get; private set; }
    public ReactionType Type { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public Reaction(Guid id, Guid projectId, Guid userId, ReactionType type, DateTimeOffset createdAt)
    {
        if (projectId == Guid.Empty)
        {
            throw new DomainException("ProjectId must not be empty");
        }

        if (userId == Guid.Empty)
        {
            throw new DomainException("UserId must not be empty");
        }

        Id = id;
        ProjectId = projectId;
        UserId = userId;
        Type = type;
        CreatedAt = createdAt;
    }
}
