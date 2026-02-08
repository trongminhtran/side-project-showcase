using Showcase.Application.Reactions;
using Showcase.Domain.Reactions;
using Showcase.Infrastructure.Persistence;

namespace Showcase.Infrastructure.Repositories;

public sealed class ReactionRepository : IReactionRepository
{
    private readonly AppDbContext _dbContext;

    public ReactionRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Reaction? GetByProjectAndUser(Guid projectId, Guid userId)
    {
        return _dbContext.Reactions.SingleOrDefault(reaction =>
            reaction.ProjectId == projectId && reaction.UserId == userId);
    }

    public void Add(Reaction reaction)
    {
        _dbContext.Reactions.Add(reaction);
    }

    public void Remove(Reaction reaction)
    {
        _dbContext.Reactions.Remove(reaction);
    }

    public ReactionCounts CountByProject(Guid projectId)
    {
        var reactions = _dbContext.Reactions.Where(reaction => reaction.ProjectId == projectId);

        var likeCount = reactions.Count(reaction => reaction.Type == ReactionType.Like);
        var dislikeCount = reactions.Count(reaction => reaction.Type == ReactionType.Dislike);
        var loveCount = reactions.Count(reaction => reaction.Type == ReactionType.Love);

        return new ReactionCounts(likeCount, dislikeCount, loveCount);
    }
}
