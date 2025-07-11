using System;
using ShowroomService.Domain.Entities;

namespace ShowroomService.Application.Dtos
{
    public record ShowroomDto(
        Guid Id,
        string? Alias,
        string Address,
        string City,
        string Country,
        string PhoneNumber,
        string OperatingHours,
        string Status,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}