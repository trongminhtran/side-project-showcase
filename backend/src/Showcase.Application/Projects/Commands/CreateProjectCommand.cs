using Showcase.Domain.Projects;

namespace Showcase.Application.Projects.Commands;

public sealed record CreateProjectCommand(Guid OwnerId, string Title, string? Description, ProjectVisibility Visibility);
