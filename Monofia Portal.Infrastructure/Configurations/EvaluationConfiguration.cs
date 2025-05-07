using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monofia_Portal.Infrastructure.Configurations
{
    public class EvaluationConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder.ToTable("Ratings");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Email)
                   .IsRequired();

            builder.Property(r => r.Description)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(r => r.Rate)
                .IsRequired();

            builder.HasOne(r => r.User)
                   .WithOne(u => u.Evaluation)
                   .HasForeignKey<Evaluation>(r => r.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
