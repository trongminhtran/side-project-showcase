using Showcase.Domain.Projects;

namespace Showcase.Application.Projects;

public interface IProjectRepository
{
    void Add(Project project);
}
