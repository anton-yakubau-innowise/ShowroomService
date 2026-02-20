using System.Data;

namespace ShowroomService.Application.Interfaces;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}