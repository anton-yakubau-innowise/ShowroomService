using AutoMapper;
using ShowroomService.Application.Dtos;
using ShowroomService.Application.Interfaces;
using ShowroomService.Domain.Entities;

namespace ShowroomService.Application.Services;

public class ShowroomApplicationService(IUnitOfWork unitOfWork, IMapper mapper) : IShowroomApplicationService
{

    public async Task<ShowroomDto?> GetShowroomByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAsync(id, cancellationToken);

        if (showroom == null)
        {
            throw new KeyNotFoundException($"Showroom with ID {id} not found.");
        }

        return mapper.Map<ShowroomDto>(showroom);
    }
    public async Task<IEnumerable<ShowroomDto>> GetAllShowroomsAsync(CancellationToken cancellationToken)
    {
        var showrooms = await unitOfWork.Showrooms.ListAllAsync(cancellationToken);

        return mapper.Map<IEnumerable<ShowroomDto>>(showrooms);
    }

    public async Task<Guid> CreateShowroomAsync(CreateShowroomRequest request, CancellationToken cancellationToken)
    {
        var showroom = Showroom.CreateShowroom(
            request.Address,
            request.City,
            request.Country,
            request.PhoneNumber,
            request.Alias);

        await unitOfWork.Showrooms.AddAsync(showroom, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return showroom.Id;
    }

    public async Task UpdateShowroomAsync(Guid id, UpdateShowroomRequest request, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAsync(id, cancellationToken);
        if (showroom == null)
        {
            throw new KeyNotFoundException($"Showroom with ID {id} not found.");
        }

        showroom.UpdateDetails(
            request.Address,
            request.City,
            request.Country,
            request.PhoneNumber,
            request.Alias);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteShowroomAsync(Guid id, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAsync(id, cancellationToken);
        if (showroom == null)
        {
            throw new KeyNotFoundException($"Showroom with ID {id} not found.");
        }

        unitOfWork.Showrooms.Delete(showroom);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

}