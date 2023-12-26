using Entites.Models;

namespace Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task CreateMovieAsync(Movie movie, CancellationToken cancellationToken = default);
        Task<IQueryable<Movie>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Movie?> GetMovieByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateMovieAsync(Movie movie, CancellationToken cancellationToken = default);
        Task DeleteMovieAsync(int id, CancellationToken cancellationToken = default);
    }
}
