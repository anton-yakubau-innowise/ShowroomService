using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShowroomService.Application.Interfaces;
using ShowroomService.Domain.Repositories;
using ShowroomService.Infrastructure.Persistence;
using ShowroomService.Infrastructure.Persistence.Repositories;

namespace ShowroomService.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ShowroomDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IShowroomRepository, ShowroomRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}