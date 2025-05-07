using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monofia_Portal.Infrastructure.Configurations
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.ToTable("Sectors");

            builder.HasKey(s => s.SectorId);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(s => s.Icon)
                   .HasMaxLength(500);

            builder.HasMany(s => s.Colleges)
                   .WithOne(c => c.Sector)
                   .HasForeignKey(c => c.SectorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}