using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ShowroomService.Domain.Entities;
using ShowroomService.Domain.Repositories;

namespace ShowroomService.Infrastructure.Persistence.Repositories
{
    public class ShowroomRepository(ShowroomDbContext dbContext) : IShowroomRepository
    {
        public async Task<Showroom?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Showrooms
                                   .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }

        public async Task<Showroom?> GetByAliasAsync(string alias, CancellationToken cancellationToken = default)
        {
            var normalizedAlias = alias.ToUpperInvariant();
            return await dbContext.Showrooms
                                   .FirstOrDefaultAsync(v => v.Alias == normalizedAlias, cancellationToken);
        }


        public async Task<bool> ExistsWithAddressAsync(string address, string city, string country, CancellationToken cancellationToken)
        {
            return await dbContext.Showrooms.AnyAsync(s => 
                s.Address == address && s.City == city && s.Country == country, 
                cancellationToken);
        }

        public async Task<IEnumerable<Showroom>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.Showrooms
                                   .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Showroom>> ListAsync(Expression<Func<Showroom, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await dbContext.Showrooms
                                   .Where(predicate)
                                   .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Showroom showroom, CancellationToken cancellationToken = default)
        {
            await dbContext.Showrooms.AddAsync(showroom, cancellationToken);
        }

        public void Delete(Showroom showroom)
        {
            dbContext.Showrooms.Remove(showroom);
        }
    }
}