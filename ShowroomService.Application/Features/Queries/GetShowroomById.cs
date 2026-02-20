using Dapper;
using MediatR;
using ShowroomService.Application.Dtos;
using ShowroomService.Application.Interfaces;

namespace ShowroomService.Application.Features.Queries;

public record GetShowroomByIdQuery(Guid Id) : IRequest<ShowroomDto?>;

public class GetShowroomByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory) : IRequestHandler<GetShowroomByIdQuery, ShowroomDto?>
{
    public async Task<ShowroomDto?> Handle(GetShowroomByIdQuery request, CancellationToken cancellationToken)
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
            FROM ""Showrooms""
            WHERE ""Id"" = @Id";

        var showroom = await connection.QueryFirstOrDefaultAsync<ShowroomDto>(sqlQuery, new { Id = request.Id });

        if (showroom == null)
        {
            throw new KeyNotFoundException($"Showroom with Id {request.Id} not found.");
        }

        return showroom;
    }
}