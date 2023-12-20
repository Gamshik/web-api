using Entites;
using Entites.Exeptions;
using Interfaces.Repositories;
using cinemaDAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinemaDAL.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaContext _context;
        public MovieRepository(CinemaContext context)
        {
            _context = context;
        }
        public async Task CreateMovieAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMovieAsync(int id, CancellationToken cancellationToken = default)
        {
            var movieForDelete = await _context.Movies.SingleOrDefaultAsync(m => m.Id == id, cancellationToken);
            if (movieForDelete == null)
            {
                throw new NotFoundException("Not found movie for delete");
            }

            _context.Movies.Remove(movieForDelete);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<IQueryable<Movie>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(_context.Movies.AsNoTracking().Include(m => m.Author));
        }
        public async Task<Movie?> GetMovieByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Movies.AsNoTracking().Include(m => m.Author).SingleOrDefaultAsync(m => m.Id == id, cancellationToken);
        }
        public async Task UpdateMovieAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }
    }
}
