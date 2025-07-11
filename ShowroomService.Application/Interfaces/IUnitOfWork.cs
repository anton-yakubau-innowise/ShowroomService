using ShowroomService.Domain.Repositories;

namespace ShowroomService.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IShowroomRepository Showrooms { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}