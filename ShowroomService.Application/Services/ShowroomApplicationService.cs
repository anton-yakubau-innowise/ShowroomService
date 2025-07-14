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
        var alreadyExists = await unitOfWork.Showrooms.ExistsWithAddressAsync(
            request.Address,
            request.City,
            request.Country,
            cancellationToken);

        if (alreadyExists)
        {
            throw new InvalidOperationException("Showroom with the same address, city, and country already exists.");
        }

        var showroom = Showroom.CreateShowroom(
            request.Address,
            request.City,
            request.Country,
            request.PhoneNumber,
            request.Alias,
            request.OperatingHours);

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

    public async Task OpenShowroomAsync(Guid id, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAsync(id, cancellationToken);
        if (showroom == null)
        {
            throw new KeyNotFoundException($"Showroom with ID {id} not found.");
        }

        showroom.Open();
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task CloseShowroomAsync(Guid id, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAsync(id, cancellationToken);
        if (showroom == null)
        {
            throw new KeyNotFoundException($"Showroom with ID {id} not found.");
        }

        showroom.Close();
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task RenovateShowroomAsync(Guid id, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAsync(id, cancellationToken);
        if (showroom == null)
        {
            throw new KeyNotFoundException($"Showroom with ID {id} not found.");
        }

        showroom.StartRenovation();
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateOperatingHoursAsync(Guid id, UpdateOperatingHoursRequest request, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAsync(id, cancellationToken);
        if (showroom == null)
        {
            throw new KeyNotFoundException($"Showroom with ID {id} not found.");
        }

        showroom.SetOperatingHours(request.OperatingHours);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}