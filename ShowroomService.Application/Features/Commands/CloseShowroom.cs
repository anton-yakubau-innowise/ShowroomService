using MediatR;
using ShowroomService.Application.Extensions;
using ShowroomService.Application.Interfaces;

namespace ShowroomService.Application.Features.Commands;

public record CloseShowroomCommand(Guid Id) : IRequest;

public class CloseShowroomCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CloseShowroomCommand>
{
    public async Task Handle(CloseShowroomCommand request, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAndEnsureExistsAsync(request.Id, cancellationToken);
        showroom.Close();
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}