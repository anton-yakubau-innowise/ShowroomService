using System.ComponentModel.DataAnnotations;

namespace ShowroomService.Application.Dtos
{
    public record CreateShowroomRequest(
        string? Alias,
        [Required] string Address,
        [Required] string City,
        [Required] string Country,
        [Required] string PhoneNumber,
        [Required] string OperatingHours
    );
}