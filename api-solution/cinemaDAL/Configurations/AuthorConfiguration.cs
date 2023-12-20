using Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinemaDAL.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Description);
            builder.Property(a => a.BirthDate).IsRequired();

            builder.HasMany(a => a.Movies)
                .WithOne(m => m.Author)
                .HasForeignKey(m => m.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
