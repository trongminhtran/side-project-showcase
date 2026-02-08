using Showcase.Application.Comments;
using Showcase.Domain.Comments;
using Showcase.Infrastructure.Persistence;

namespace Showcase.Infrastructure.Repositories;

public sealed class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _dbContext;

    public CommentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Comment? GetById(Guid commentId)
    {
        return _dbContext.Comments.SingleOrDefault(comment => comment.Id == commentId);
    }

    public void Add(Comment comment)
    {
        _dbContext.Comments.Add(comment);
    }
}
