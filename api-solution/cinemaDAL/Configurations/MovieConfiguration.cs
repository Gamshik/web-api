using Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinemaDAL.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Title).IsRequired();
            builder.Property(m => m.Description);
            builder.Property(m => m.ReleaseDate).IsRequired();

            builder.HasOne(m => m.Author)
                .WithMany(a => a.Movies)
                .HasForeignKey(m => m.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
