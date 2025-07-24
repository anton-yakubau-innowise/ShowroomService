namespace ShowroomService.Application.Dtos
{
    public record UpdateShowroomRequest(
        string? Alias = null,
        string? Address = null,
        string? City = null,
        string? Country = null,
        string? PhoneNumber = null
    );
}