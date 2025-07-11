namespace ShowroomService.Application.Dtos
{
    public record UpdateShowroomRequest(
        string? Alias,
        string? Address,
        string? City,
        string? Country,
        string? PhoneNumber,
        string? OperatingHours
    );
}