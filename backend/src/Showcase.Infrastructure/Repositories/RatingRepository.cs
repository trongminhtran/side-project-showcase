using Showcase.Application.Ratings;
using Showcase.Domain.Ratings;
using Showcase.Infrastructure.Persistence;

namespace Showcase.Infrastructure.Repositories;

public sealed class RatingRepository : IRatingRepository
{
    private readonly AppDbContext _dbContext;

    public RatingRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Rating? GetByProjectAndUser(Guid projectId, Guid userId)
    {
        return _dbContext.Ratings.SingleOrDefault(rating =>
            rating.ProjectId == projectId && rating.UserId == userId);
    }

    public void Add(Rating rating)
    {
        _dbContext.Ratings.Add(rating);
    }

    public void Remove(Rating rating)
    {
        _dbContext.Ratings.Remove(rating);
    }

    public double GetAverageScore(Guid projectId)
    {
        return _dbContext.Ratings
            .Where(rating => rating.ProjectId == projectId)
            .Select(rating => (double)rating.Score)
            .DefaultIfEmpty(0)
            .Average();
    }
}
