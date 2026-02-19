using MediatR;
using ShowroomService.Application.Extensions;
using ShowroomService.Application.Interfaces;

namespace ShowroomService.Application.Features.Commands;

public record RenovateShowroomCommand(Guid Id) : IRequest;

public class RenovateShowroomCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<RenovateShowroomCommand>
{
    public async Task Handle(RenovateShowroomCommand request, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAndEnsureExistsAsync(request.Id, cancellationToken);
        showroom.StartRenovation();
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}