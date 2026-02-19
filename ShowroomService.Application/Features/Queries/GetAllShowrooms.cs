using AutoMapper;
using MediatR;
using ShowroomService.Application.Dtos;
using ShowroomService.Application.Interfaces;

namespace ShowroomService.Application.Features.Queries;

public record GetAllShowroomsQuery : IRequest<IEnumerable<ShowroomDto>>;

public class GetAllShowroomsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllShowroomsQuery, IEnumerable<ShowroomDto>>
{
    public async Task<IEnumerable<ShowroomDto>> Handle(GetAllShowroomsQuery request, CancellationToken cancellationToken)
    {
        var showrooms = await unitOfWork.Showrooms.ListAllAsync(cancellationToken);

        return mapper.Map<IEnumerable<ShowroomDto>>(showrooms);
    }
}

