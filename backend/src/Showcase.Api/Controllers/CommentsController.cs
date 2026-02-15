using Microsoft.AspNetCore.Mvc;
using Showcase.Api.Contracts;
using Showcase.Application.Comments.Commands;

namespace Showcase.Api.Controllers;

[ApiController]
[Route("api/v1/projects/{projectId}/comments")]
public sealed class CommentsController : ControllerBase
{
    private readonly CommentProjectCommandHandler _handler;

    public CommentsController(CommentProjectCommandHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public IActionResult Comment(Guid projectId, [FromBody] CommentProjectRequest request)
    {
        var userId = GetUserId();

        var command = new CommentProjectCommand(
            projectId,
            userId,
            request.Content,
            request.ParentCommentId);

        var commentId = _handler.Handle(command);

        return Created(string.Empty, new { commentId });
    }

    private Guid GetUserId()
    {
        // TODO: Extract from User principal or custom header
        // For now, return a placeholder
        var userIdClaim = User.FindFirst("sub")?.Value;
        if (Guid.TryParse(userIdClaim, out var userId))
        {
            return userId;
        }

        throw new InvalidOperationException("User ID not found in claims");
    }
}

internal sealed record CommentProjectResponse(Guid CommentId);
