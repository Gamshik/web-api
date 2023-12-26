using cinemaDAL.Configurations;
using Entites.Models;
using Microsoft.EntityFrameworkCore;

namespace cinemaDAL.Context
{
    public class CinemaContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
        }
    }
}
