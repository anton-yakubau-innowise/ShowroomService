using Microsoft.AspNetCore.Mvc;
using ShowroomService.Application.Dtos;
using ShowroomService.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ShowroomsController(IShowroomApplicationService showroomService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ShowroomDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllShowrooms()
    {
        var showrooms = await showroomService.GetAllShowroomsAsync();
        return Ok(showrooms);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ShowroomDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetShowroomById(Guid id)
    {
        var showroom = await showroomService.GetShowroomByIdAsync(id);
        return Ok(showroom);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateShowroom([FromBody] CreateShowroomRequest request)
    {
        var showroomId = await showroomService.CreateShowroomAsync(request);
        return CreatedAtAction(nameof(GetShowroomById), new { id = showroomId }, showroomId);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateShowroom(Guid id, [FromBody] UpdateShowroomRequest request)
    {
        await showroomService.UpdateShowroomAsync(id, request);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteShowroom(Guid id)
    {
        await showroomService.DeleteShowroomAsync(id);
        return NoContent();
    }

}