using Showcase.Application.Projects;
using Showcase.Domain.Comments;
using Showcase.Domain.Projects;

namespace Showcase.Application.Comments.Commands;

public sealed class CommentProjectCommandHandler
{
    private readonly IProjectRepository _projectRepository;
    private readonly ICommentRepository _commentRepository;

    public CommentProjectCommandHandler(IProjectRepository projectRepository, ICommentRepository commentRepository)
    {
        _projectRepository = projectRepository;
        _commentRepository = commentRepository;
    }

    public Guid Handle(CommentProjectCommand command)
    {
        var project = _projectRepository.GetById(command.ProjectId);

        if (project is null)
        {
            throw new InvalidOperationException("Project not found");
        }

        if (project.Visibility == ProjectVisibility.Private)
        {
            throw new InvalidOperationException("Project is private");
        }

        if (command.ParentCommentId.HasValue)
        {
            var parent = _commentRepository.GetById(command.ParentCommentId.Value);

            if (parent is null)
            {
                throw new InvalidOperationException("Parent comment not found");
            }

            if (parent.ParentCommentId is not null)
            {
                throw new InvalidOperationException("Only one level of replies is allowed");
            }
        }

        var comment = new Comment(
            Guid.NewGuid(),
            command.ProjectId,
            command.UserId,
            command.Content,
            command.ParentCommentId,
            DateTimeOffset.UtcNow);

        _commentRepository.Add(comment);

        return comment.Id;
    }
}
