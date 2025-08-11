using Microsoft.EntityFrameworkCore;
using ShowroomService.API.Middleware;
using ShowroomService.Application;
using ShowroomService.Infrastructure;
using ShowroomService.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCustomExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ShowroomDbContext>();
        dbContext.Database.Migrate();
    }
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();