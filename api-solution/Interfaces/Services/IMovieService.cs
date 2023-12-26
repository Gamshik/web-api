using Entites.DataTransferObject.MovieDtos;

namespace Interfaces.Services
{
    public interface IMovieService
    {
        Task CreateMovieAsync(MovieForCreateDto movie, CancellationToken cancellationToken = default);
        Task<IEnumerable<MovieDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<MovieDto> GetMovieByIdAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateMovieAsync(MovieForUpdateDto movie, CancellationToken cancellationToken = default);
        Task DeleteMovieAsync(int id, CancellationToken cancellationToken = default);
    }
}
