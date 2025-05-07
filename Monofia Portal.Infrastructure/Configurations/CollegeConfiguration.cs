using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monofia_Portal.Infrastructure.Configurations
{
    public class CollegeConfiguration : IEntityTypeConfiguration<College>
    {
        public void Configure(EntityTypeBuilder<College> builder)
        {
            builder.ToTable("Colleges");

            builder.HasKey(c => c.CollegeId);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasOne(c => c.Sector)
                   .WithMany(s => s.Colleges)
                   .HasForeignKey(c => c.SectorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ProgramSystems)
                   .WithOne(ps => ps.College)
                   .HasForeignKey(ps => ps.CollegeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}