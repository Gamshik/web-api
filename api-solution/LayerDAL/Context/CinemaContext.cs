using Entites;
using LayerDAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LayerDAL.Context
{
    public class CinemaContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public CinemaContext(DbContextOptions options) : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
        }
    }
}
