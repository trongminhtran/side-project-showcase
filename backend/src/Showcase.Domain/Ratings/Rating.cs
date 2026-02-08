using Showcase.Domain.Common;

namespace Showcase.Domain.Ratings;

public class Rating
{
    public Guid Id { get; private set; }
    public Guid ProjectId { get; private set; }
    public Guid UserId { get; private set; }
    public int Score { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public Rating(Guid id, Guid projectId, Guid userId, int score, DateTimeOffset createdAt)
    {
        if (projectId == Guid.Empty)
        {
            throw new DomainException("ProjectId must not be empty");
        }

        if (userId == Guid.Empty)
        {
            throw new DomainException("UserId must not be empty");
        }

        if (score < 1 || score > 5)
        {
            throw new DomainException("Score must be between 1 and 5");
        }

        Id = id;
        ProjectId = projectId;
        UserId = userId;
        Score = score;
        CreatedAt = createdAt;
    }
}
