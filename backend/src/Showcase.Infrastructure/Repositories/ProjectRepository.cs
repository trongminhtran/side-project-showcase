using Showcase.Application.Projects;
using Showcase.Domain.Projects;
using Showcase.Infrastructure.Persistence;

namespace Showcase.Infrastructure.Repositories;

public sealed class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _dbContext;

    public ProjectRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Project project)
    {
        _dbContext.Projects.Add(project);
    }

    public Project? GetById(Guid projectId)
    {
        return _dbContext.Projects.SingleOrDefault(project => project.Id == projectId);
    }
}
