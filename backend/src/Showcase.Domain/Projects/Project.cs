using Showcase.Domain.Common;

namespace Showcase.Domain.Projects;

public class Project
{
    public Guid Id { get; private set; }
    public Guid OwnerId { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public ProjectVisibility Visibility { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public Project(Guid id, Guid ownerId, string title, string? description, ProjectVisibility visibility, DateTimeOffset createdAt)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new DomainException("Title must not be empty");
        }

        Id = id;
        OwnerId = ownerId;
        Title = title;
        Description = description;
        Visibility = visibility;
        CreatedAt = createdAt;
    }
}
