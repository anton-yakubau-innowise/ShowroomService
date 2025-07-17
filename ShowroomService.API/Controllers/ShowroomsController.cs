using Microsoft.AspNetCore.Mvc;
using ShowroomService.Application.Dtos;
using ShowroomService.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ShowroomsController(IShowroomApplicationService showroomService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ShowroomDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllShowrooms(CancellationToken cancellationToken)
    {
        var showrooms = await showroomService.GetAllShowroomsAsync(cancellationToken);
        return Ok(showrooms);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ShowroomDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetShowroomById(Guid id, CancellationToken cancellationToken)
    {
        var showroom = await showroomService.GetShowroomByIdAsync(id, cancellationToken);
        return Ok(showroom);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateShowroom([FromBody] CreateShowroomRequest request, CancellationToken cancellationToken)
    {
        var showroomId = await showroomService.CreateShowroomAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetShowroomById), new { id = showroomId }, showroomId);
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateShowroom(Guid id, [FromBody] UpdateShowroomRequest request, CancellationToken cancellationToken)
    {
        await showroomService.UpdateShowroomAsync(id, request, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteShowroom(Guid id, CancellationToken cancellationToken)
    {
        await showroomService.DeleteShowroomAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:guid}/open")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> OpenShowroom(Guid id, CancellationToken cancellationToken)
    {
        await showroomService.OpenShowroomAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:guid}/close")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CloseShowroom(Guid id, CancellationToken cancellationToken)
    {
        await showroomService.CloseShowroomAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPost("{id:guid}/renovate")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RenovateShowroom(Guid id, CancellationToken cancellationToken)
    {
        await showroomService.RenovateShowroomAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}/operating-hours")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateOperatingHours(Guid id, [FromBody] UpdateOperatingHoursRequest request, CancellationToken cancellationToken)
    {
        await showroomService.UpdateOperatingHoursAsync(id, request, cancellationToken);
        return NoContent();
    }
}