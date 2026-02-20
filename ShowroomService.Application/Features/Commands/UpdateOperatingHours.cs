using System.Text.Json.Serialization;
using MediatR;
using ShowroomService.Application.Extensions;
using ShowroomService.Application.Interfaces;

namespace ShowroomService.Application.Features.Commands;

public record UpdateOperatingHoursCommand([property: JsonIgnore]Guid Id, string OperatingHours) : IRequest;

public class UpdateOperatingHoursCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateOperatingHoursCommand>
{
    public async Task Handle(UpdateOperatingHoursCommand request, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAndEnsureExistsAsync(request.Id, cancellationToken);
        showroom.SetOperatingHours(request.OperatingHours);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}