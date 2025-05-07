using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monofia_Portal.Infrastructure.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Description)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.HasOne(r => r.User)
                   .WithMany(u => u.Ratings)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
