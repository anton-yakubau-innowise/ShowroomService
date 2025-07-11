namespace ShowroomService.Application.Dtos
{
    public record CreateShowroomRequest(
        string? Alias,
        string Address,
        string City,
        string Country,
        string PhoneNumber,
        string OperatingHours
    );
}