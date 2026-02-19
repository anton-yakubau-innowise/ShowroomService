using System.Text.Json.Serialization;
using MediatR;
using ShowroomService.Application.Extensions;
using ShowroomService.Application.Interfaces;

namespace ShowroomService.Application.Features.Commands;

public record UpdateShowroomCommand(
        [property: JsonIgnore]Guid Id,
        string? Alias = null,
        string? Address = null,
        string? City = null,
        string? Country = null,
        string? PhoneNumber = null
    ) : IRequest;


public class UpdateShowroomCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateShowroomCommand>
{
    public async Task Handle(UpdateShowroomCommand request, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAndEnsureExistsAsync(request.Id, cancellationToken);

        showroom.UpdateDetails(
            request.Alias,
            request.PhoneNumber,
            request.Address,
            request.City,
            request.Country);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}