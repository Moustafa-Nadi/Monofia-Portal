using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monofia_Portal.Infrastructure.Configurations
{
    public class SuggestionConfiguration : IEntityTypeConfiguration<Suggestion>
    {
        public void Configure(EntityTypeBuilder<Suggestion> builder)
        {
            builder.ToTable("Suggestions");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Description)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.HasOne(s => s.User)
                   .WithMany(u => u.Suggestions)
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
