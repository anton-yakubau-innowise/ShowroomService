using MediatR;
using ShowroomService.Application.Extensions;
using ShowroomService.Application.Interfaces;

namespace ShowroomService.Application.Features.Commands;

public record OpenShowroomCommand(Guid Id) : IRequest;

public class OpenShowroomCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<OpenShowroomCommand>
{
    public async Task Handle(OpenShowroomCommand request, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAndEnsureExistsAsync(request.Id, cancellationToken);

        showroom.Open();
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}