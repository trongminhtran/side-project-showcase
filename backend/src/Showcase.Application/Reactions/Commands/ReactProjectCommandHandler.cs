using Showcase.Application.Projects;
using Showcase.Domain.Projects;
using Showcase.Domain.Reactions;

namespace Showcase.Application.Reactions.Commands;

public sealed class ReactProjectCommandHandler
{
    private readonly IProjectRepository _projectRepository;
    private readonly IReactionRepository _reactionRepository;

    public ReactProjectCommandHandler(IProjectRepository projectRepository, IReactionRepository reactionRepository)
    {
        _projectRepository = projectRepository;
        _reactionRepository = reactionRepository;
    }

    public ReactionCounts Handle(ReactProjectCommand command)
    {
        var project = _projectRepository.GetById(command.ProjectId);

        if (project is null)
        {
            throw new InvalidOperationException("Project not found");
        }

        if (project.Visibility == ProjectVisibility.Private)
        {
            throw new InvalidOperationException("Project is private");
        }

        var existingReaction = _reactionRepository.GetByProjectAndUser(command.ProjectId, command.UserId);

        if (existingReaction is not null)
        {
            _reactionRepository.Remove(existingReaction);
        }

        var reaction = new Reaction(
            Guid.NewGuid(),
            command.ProjectId,
            command.UserId,
            command.Type,
            DateTimeOffset.UtcNow);

        _reactionRepository.Add(reaction);

        return _reactionRepository.CountByProject(command.ProjectId);
    }
}
