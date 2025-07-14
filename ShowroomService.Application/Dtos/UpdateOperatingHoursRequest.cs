using System.ComponentModel.DataAnnotations;

namespace ShowroomService.Application.Dtos;

public record UpdateOperatingHoursRequest(
        [Required]
        [StringLength(100, MinimumLength = 5)]
        string OperatingHours
    );