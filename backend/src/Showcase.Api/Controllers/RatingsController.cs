using Microsoft.AspNetCore.Mvc;
using Showcase.Api.Contracts;
using Showcase.Application.Ratings.Commands;

namespace Showcase.Api.Controllers;

[ApiController]
[Route("api/v1/projects/{projectId}/ratings")]
public sealed class RatingsController : ControllerBase
{
    private readonly RateProjectCommandHandler _handler;

    public RatingsController(RateProjectCommandHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public IActionResult Rate(Guid projectId, [FromBody] RateProjectRequest request)
    {
        var userId = GetUserId();

        var command = new RateProjectCommand(projectId, userId, request.Score);

        var result = _handler.Handle(command);

        return Ok(new RateProjectResponse(result.AverageScore, result.UserScore));
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

internal sealed record RateProjectResponse(double Average, int UserScore);
