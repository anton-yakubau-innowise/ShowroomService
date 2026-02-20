using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using ShowroomService.Application.Interfaces;

namespace ShowroomService.Infrastructure;

public class SqlConnectionFactory(IConfiguration configuration) : ISqlConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        var connectionString = configuration.GetConnectionString("ReadConnection");
        
        return new NpgsqlConnection(connectionString);
    }
}