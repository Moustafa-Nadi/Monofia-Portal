using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monofia_Portal.Infrastructure.Configurations
{
    public class SystemDetailConfiguration : IEntityTypeConfiguration<SystemDetail>
    {
        public void Configure(EntityTypeBuilder<SystemDetail> builder)
        {
            builder.ToTable("SystemDetails");

            builder.HasKey(sd => sd.SystemDetailId);

            builder.Property(sd => sd.Text)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.HasOne(sd => sd.ProgramSystem)
                   .WithMany(ps => ps.SystemDetails)
                   .HasForeignKey(sd => sd.ProgramSystemId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
