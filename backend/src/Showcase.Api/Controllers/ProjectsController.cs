using Microsoft.AspNetCore.Mvc;
using Showcase.Api.Contracts;
using Showcase.Application.Projects.Commands;

namespace Showcase.Api.Controllers;

[ApiController]
[Route("api/v1/projects")]
public sealed class ProjectsController : ControllerBase
{
    private readonly CreateProjectCommandHandler _handler;

    public ProjectsController(CreateProjectCommandHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProjectRequest request)
    {
        var userId = GetUserId();

        var command = new CreateProjectCommand(
            userId,
            request.Title,
            request.Description,
            request.Visibility);

        var projectId = _handler.Handle(command);

        return Created(string.Empty, new { projectId });
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

internal sealed record CreateProjectResponse(Guid ProjectId);
