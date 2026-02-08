using Showcase.Domain.Ratings;

namespace Showcase.Application.Ratings;

public interface IRatingRepository
{
    Rating? GetByProjectAndUser(Guid projectId, Guid userId);
    void Add(Rating rating);
    void Remove(Rating rating);
    double GetAverageScore(Guid projectId);
}
