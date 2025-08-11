using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ShowroomService.Application.Interfaces;
using ShowroomService.Application.Services;

namespace ShowroomService.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IShowroomApplicationService, ShowroomApplicationService>();

            return services;
        }
    }
}