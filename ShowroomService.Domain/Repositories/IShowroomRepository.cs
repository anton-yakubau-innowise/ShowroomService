using System.Linq.Expressions;
using ShowroomService.Domain.Entities;

namespace ShowroomService.Domain.Repositories
{
    public interface IShowroomRepository
    {
        Task<Showroom?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Showroom?> GetByAliasAsync(string alias, CancellationToken cancellationToken = default);
        Task<IEnumerable<Showroom>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<Showroom>> ListAsync(Expression<Func<Showroom, bool>> predicate, CancellationToken cancellationToken = default);

        Task AddAsync(Showroom showroom, CancellationToken cancellationToken = default);
        void Delete(Showroom showroom);
    }
}