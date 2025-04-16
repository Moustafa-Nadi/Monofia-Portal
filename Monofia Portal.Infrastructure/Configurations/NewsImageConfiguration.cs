using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monofia_Portal.Infrastructure.Configurations
{
    public class NewsImageConfiguration : IEntityTypeConfiguration<NewsImage>
    {
        public void Configure(EntityTypeBuilder<NewsImage> builder)
        {
            builder.HasOne(i => i.PortalNews)
                   .WithMany(n => n.Images)
                   .HasForeignKey(i => i.NewsId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
