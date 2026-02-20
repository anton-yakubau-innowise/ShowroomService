using Dapper;
using MediatR;
using ShowroomService.Application.Dtos;
using ShowroomService.Application.Interfaces;

namespace ShowroomService.Application.Features.Queries;

public record GetAllShowroomsQuery : IRequest<IEnumerable<ShowroomDto>>;

public class GetAllShowroomsQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IRequestHandler<GetAllShowroomsQuery, IEnumerable<ShowroomDto>>
{
    public async Task<IEnumerable<ShowroomDto>> Handle(GetAllShowroomsQuery request, CancellationToken cancellationToken)
    {
        using var connection = sqlConnectionFactory.CreateConnection();

        const string sqlQuery = @"
            SELECT
                ""Id"", 
                ""Alias"", 
                ""Address"", 
                ""City"", 
                ""Country"", 
                ""PhoneNumber"", 
                ""OperatingHours"", 
                ""Status"", 
                ""CreatedAt"", 
                ""UpdatedAt""
            FROM ""Showrooms""";

        var showrooms = await connection.QueryAsync<ShowroomDto>(sqlQuery);

        return showrooms;
    }
}

