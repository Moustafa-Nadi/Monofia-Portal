using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monofia_Portal.Infrastructure.Configurations
{
    public class ProgramSystemConfiguration : IEntityTypeConfiguration<ProgramSystem>
    {
        public void Configure(EntityTypeBuilder<ProgramSystem> builder)
        {
            builder.ToTable("ProgramSystems");

            builder.HasKey(ps => ps.ProgramSystemId);

            builder.Property(ps => ps.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasOne(ps => ps.College)
                   .WithMany(c => c.ProgramSystems)
                   .HasForeignKey(ps => ps.CollegeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ps => ps.SystemDetails)
                   .WithOne(sd => sd.ProgramSystem)
                   .HasForeignKey(sd => sd.ProgramSystemId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
