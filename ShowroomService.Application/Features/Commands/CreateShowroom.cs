using MediatR;
using ShowroomService.Application.Interfaces;
using ShowroomService.Domain.Entities;

namespace ShowroomService.Application.Features.Commands;

public record CreateShowroomCommand(
    string Address,
    string City,
    string Country,
    string PhoneNumber,
    string Alias,
    string OperatingHours
) : IRequest<Guid>;

public class CreateShowroomCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateShowroomCommand, Guid>
{
    public async Task<Guid> Handle(CreateShowroomCommand request, CancellationToken cancellationToken)
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
}