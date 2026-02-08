namespace Showcase.Application.Ratings.Commands;

public sealed record RateProjectCommand(Guid ProjectId, Guid UserId, int Score);
