using Microsoft.AspNetCore.Mvc;
using Showcase.Api.Contracts;
using Showcase.Application.Reactions.Commands;

namespace Showcase.Api.Controllers;

[ApiController]
[Route("api/v1/projects/{projectId}/reactions")]
public sealed class ReactionsController : ControllerBase
{
    private readonly ReactProjectCommandHandler _handler;

    public ReactionsController(ReactProjectCommandHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public IActionResult React(Guid projectId, [FromBody] ReactProjectRequest request)
    {
        var userId = GetUserId();

        var command = new ReactProjectCommand(projectId, userId, request.Type);

        var result = _handler.Handle(command);

        return Ok(new ReactProjectResponse(result.Like, result.Dislike, result.Love));
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

internal sealed record ReactProjectResponse(int LikeCount, int DislikeCount, int LoveCount);
