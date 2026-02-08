using Showcase.Domain.Projects;

namespace Showcase.Application.Projects.Commands;

public sealed class CreateProjectCommandHandler
{
    private readonly IProjectRepository _repository;

    public CreateProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public Guid Handle(CreateProjectCommand command)
    {
        var project = new Project(
            Guid.NewGuid(),
            command.OwnerId,
            command.Title,
            command.Description,
            command.Visibility,
            DateTimeOffset.UtcNow);

        _repository.Add(project);

        return project.Id;
    }
}
