using Showcase.Application.Projects;
using Showcase.Domain.Projects;
using Showcase.Domain.Ratings;

namespace Showcase.Application.Ratings.Commands;

public sealed class RateProjectCommandHandler
{
    private readonly IProjectRepository _projectRepository;
    private readonly IRatingRepository _ratingRepository;

    public RateProjectCommandHandler(IProjectRepository projectRepository, IRatingRepository ratingRepository)
    {
        _projectRepository = projectRepository;
        _ratingRepository = ratingRepository;
    }

    public RateProjectResult Handle(RateProjectCommand command)
    {
        if (command.Score < 1 || command.Score > 5)
        {
            throw new InvalidOperationException("Score must be between 1 and 5");
        }

        var project = _projectRepository.GetById(command.ProjectId);

        if (project is null)
        {
            throw new InvalidOperationException("Project not found");
        }

        if (project.Visibility == ProjectVisibility.Private)
        {
            throw new InvalidOperationException("Project is private");
        }

        var existingRating = _ratingRepository.GetByProjectAndUser(command.ProjectId, command.UserId);

        if (existingRating is not null)
        {
            _ratingRepository.Remove(existingRating);
        }

        var rating = new Rating(
            Guid.NewGuid(),
            command.ProjectId,
            command.UserId,
            command.Score,
            DateTimeOffset.UtcNow);

        _ratingRepository.Add(rating);

        var averageScore = _ratingRepository.GetAverageScore(command.ProjectId);

        return new RateProjectResult(averageScore, command.Score);
    }
}

public sealed record RateProjectResult(double AverageScore, int UserScore);
