using ShowroomService.Domain.Entities;
using ShowroomService.Domain.Repositories;

namespace ShowroomService.Application.Extensions;

public static class ShowroomRepositoryExtensions
{
    public static async Task<Showroom> GetByIdAndEnsureExistsAsync(this IShowroomRepository repository, Guid id, CancellationToken cancellationToken)
    {
        var showroom = await repository.GetByIdAsync(id, cancellationToken);

        if (showroom is null)
        {
            throw new KeyNotFoundException($"Showroom with ID {id} not found.");
        }

        return showroom;
    }
}