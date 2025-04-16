using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monofia_Portal.Infrastructure.Configurations
{
    public class PortalNewsConfiguration : IEntityTypeConfiguration<PortalNews>
    {
        public void Configure(EntityTypeBuilder<PortalNews> builder)
        {
            builder.ToTable("prtl_News");

            builder.HasKey(n => n.News_Id);

            builder.Property(n => n.IsFeature)
                .HasDefaultValue(false);

            builder.Property(n => n.Date)
                   .HasColumnName("News_date")
                   .IsRequired();

            builder.Property(n => n.Image)
                   .HasColumnName("News_img");

            builder.Property(n => n.OwnerId)
                    .HasColumnName("Owner_ID")
                   .IsRequired();

            builder.HasMany(n => n.Translations)
                   .WithOne(t => t.News)
                   .HasForeignKey(t => t.NewsId);
        }
    }
}
