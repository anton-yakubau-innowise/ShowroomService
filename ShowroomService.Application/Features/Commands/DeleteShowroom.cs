using MediatR;
using ShowroomService.Application.Extensions;
using ShowroomService.Application.Interfaces;

namespace ShowroomService.Application.Features.Commands;

public record DeleteShowroomCommand(Guid Id) : IRequest;

public class DeleteShowroomCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteShowroomCommand>
{
    public async Task Handle(DeleteShowroomCommand request, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAndEnsureExistsAsync(request.Id, cancellationToken);

        unitOfWork.Showrooms.Delete(showroom);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}