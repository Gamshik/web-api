using Entites.DataTransferObject;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace cinemaApi.Controllers
{
    [ApiController]
    [Route("api/Movie")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMoviesAsync(CancellationToken cancellationToken)
        {
            var movies = await _movieService.GetAllAsync(cancellationToken);
            return Ok(movies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieByIdAsync(int id, CancellationToken cancellationToken)
        {
            var movie = await _movieService.GetMovieByIdAsync(id, cancellationToken);
            return Ok(movie);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovieAsync(MovieForCreateDto movieForCreateDto, CancellationToken cancellationToken)
        {
            await _movieService.CreateMovieAsync(movieForCreateDto, cancellationToken);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovieAsync(MovieForUpdateDto movieForUpdateDto, CancellationToken cancellationToken)
        {
            await _movieService.UpdateMovieAsync(movieForUpdateDto, cancellationToken);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMovieAsync(int id, CancellationToken cancellationToken)
        {
            await _movieService.DeleteMovieAsync(id, cancellationToken);
            return Ok();
        }
    }
}
