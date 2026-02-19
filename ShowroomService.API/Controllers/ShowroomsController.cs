using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShowroomService.Application.Dtos;
using ShowroomService.Application.Features.Commands;
using ShowroomService.Application.Features.Queries;

[ApiController]
[Route("api/[controller]")]
public class ShowroomsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ShowroomDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllShowrooms(CancellationToken cancellationToken)
    {
        var showrooms = await mediator.Send(new GetAllShowroomsQuery(), cancellationToken);
        return Ok(showrooms);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ShowroomDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetShowroomById(Guid id, CancellationToken cancellationToken)
    {
        var showroom = await mediator.Send(new GetShowroomByIdQuery(id), cancellationToken);
        return Ok(showroom);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateShowroom([FromBody] CreateShowroomCommand command, CancellationToken cancellationToken)
    {
        var showroomId = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetShowroomById), new { id = showroomId }, showroomId);
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateShowroom(Guid id, [FromBody] UpdateShowroomCommand command, CancellationToken cancellationToken)
    {
        command = command with { Id = id };
        await mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteShowroom(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteShowroomCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:guid}/open")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> OpenShowroom(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new OpenShowroomCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:guid}/close")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CloseShowroom(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new CloseShowroomCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:guid}/renovate")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RenovateShowroom(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new RenovateShowroomCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}/operating-hours")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateOperatingHours(Guid id, [FromBody] UpdateOperatingHoursCommand command, CancellationToken cancellationToken)
    {
        command = command with { Id = id };
        await mediator.Send(command, cancellationToken);
        return NoContent();
    }
}