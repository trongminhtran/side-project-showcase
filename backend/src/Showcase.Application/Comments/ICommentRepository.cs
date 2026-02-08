using Showcase.Domain.Comments;

namespace Showcase.Application.Comments;

public interface ICommentRepository
{
    Comment? GetById(Guid commentId);
    void Add(Comment comment);
}
