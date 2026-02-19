using AutoMapper;
using MediatR;
using ShowroomService.Application.Dtos;
using ShowroomService.Application.Extensions;
using ShowroomService.Application.Interfaces;

namespace ShowroomService.Application.Features.Queries;

public record GetShowroomByIdQuery(Guid Id) : IRequest<ShowroomDto?>;

public class GetShowroomByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetShowroomByIdQuery, ShowroomDto?>
{
    public async Task<ShowroomDto?> Handle(GetShowroomByIdQuery request, CancellationToken cancellationToken)
    {
        var showroom = await unitOfWork.Showrooms.GetByIdAndEnsureExistsAsync(request.Id, cancellationToken);

        return mapper.Map<ShowroomDto>(showroom);
    }
}