using Entites;
using LayerDAL.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerDAL.Context
{
    public class CinemaContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public CinemaContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
        }
    }
}
