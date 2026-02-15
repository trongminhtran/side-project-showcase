using Showcase.Domain.Projects;

namespace Showcase.Api.Contracts;

public sealed record CreateProjectRequest(string Title, string? Description, ProjectVisibility Visibility);
