using AutoMapper;
using Entites.DataTransferObject.MovieDtos;
using Entites.Models;
using FluentValidation;
using Interfaces.Repositories;
using Interfaces.Services;

namespace cinemaBLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Movie> _validator;
        public MovieService(IMovieRepository movieRepository, IMapper mapper, IValidator<Movie> validator)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task CreateMovieAsync(MovieForCreateDto movie, CancellationToken cancellationToken = default)
        {
            var movieForCreate = _mapper.Map<Movie>(movie);

            _validator.ValidateAndThrow(movieForCreate);

            await _movieRepository.CreateMovieAsync(movieForCreate, cancellationToken);
        }
        public async Task DeleteMovieAsync(int id, CancellationToken cancellationToken = default)
        {
            await _movieRepository.DeleteMovieAsync(id, cancellationToken);
        }
        public async Task<IEnumerable<MovieDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<MovieDto>>(await _movieRepository.GetAllAsync(cancellationToken));
        }
        public async Task<MovieDto> GetMovieByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<MovieDto>(await _movieRepository.GetMovieByIdAsync(id, cancellationToken));
        }
        public async Task UpdateMovieAsync(MovieForUpdateDto movie, CancellationToken cancellationToken = default)
        {
            var movieForUpdate = _mapper.Map<Movie>(movie);

            _validator.ValidateAndThrow(movieForUpdate);

            await _movieRepository.UpdateMovieAsync(movieForUpdate, cancellationToken);
        }
    }
}
