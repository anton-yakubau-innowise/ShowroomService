using ShowroomService.Application.Interfaces;
using ShowroomService.Domain.Repositories;
using ShowroomService.Infrastructure.Persistence.Repositories;

namespace ShowroomService.Infrastructure.Persistence
{
public class UnitOfWork(ShowroomDbContext dbContext) : IUnitOfWork
{
    public IShowroomRepository Showrooms { get; } = new ShowroomRepository(dbContext);

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return dbContext.SaveChangesAsync(cancellationToken);
        }

    public void Dispose()
    {
        dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}
}