using Showcase.Domain.Reactions;

namespace Showcase.Application.Reactions;

public interface IReactionRepository
{
    Reaction? GetByProjectAndUser(Guid projectId, Guid userId);
    void Add(Reaction reaction);
    void Remove(Reaction reaction);
    ReactionCounts CountByProject(Guid projectId);
}

public sealed record ReactionCounts(int Like, int Dislike, int Love);
