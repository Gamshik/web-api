using Entites.Models;

namespace Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Task CreateAuthorAsync(Author author, CancellationToken cancellationToken = default);
        Task<IQueryable<Author>> GetAllAuthorAsync(CancellationToken cancellationToken = default);
        Task<Author?> GetAuthorByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateAuthorAsync(Author author, CancellationToken cancellationToken = default);
        Task DeleteAuthorAsync(int id, CancellationToken cancellationToken = default);
    }
}
