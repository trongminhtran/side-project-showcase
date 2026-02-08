using Showcase.Domain.Reactions;

namespace Showcase.Application.Reactions.Commands;

public sealed record ReactProjectCommand(Guid ProjectId, Guid UserId, ReactionType Type);
