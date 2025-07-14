using ShowroomService.Application.Dtos;

namespace ShowroomService.Application.Interfaces;

public interface IShowroomApplicationService
{
    Task<ShowroomDto?> GetShowroomByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ShowroomDto>> GetAllShowroomsAsync(CancellationToken cancellationToken = default);
    Task<Guid> CreateShowroomAsync(CreateShowroomRequest request, CancellationToken cancellationToken = default);
    Task UpdateShowroomAsync(Guid id, UpdateShowroomRequest request, CancellationToken cancellationToken = default);
    Task DeleteShowroomAsync(Guid id, CancellationToken cancellationToken = default);
    Task OpenShowroomAsync(Guid id, CancellationToken cancellationToken = default);
    Task CloseShowroomAsync(Guid id, CancellationToken cancellationToken = default);
    Task RenovateShowroomAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateOperatingHoursAsync(Guid id, UpdateOperatingHoursRequest request, CancellationToken cancellationToken = default);

}