using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monofia_Portal.Infrastructure.Configurations
{
    public class NewsTranslationConfiguration : IEntityTypeConfiguration<NewsTranslation>
    {
        public void Configure(EntityTypeBuilder<NewsTranslation> builder)
        {
            builder.ToTable("prtl_News_Translations");

            builder.HasKey(nt => nt.Id);

            builder.Property(nt => nt.Header)
                .HasColumnName("News_Head")
                   .IsRequired();
            builder.Property(nt => nt.Abbreviation)
                   .HasColumnName("News_Abbr");

            builder.Property(nt => nt.Body)
                   .HasColumnName("News_Body")
                   .IsRequired();

            builder.Property(nt => nt.Source)
                   .HasColumnName("News_Source")
                   .IsRequired();

            builder.Property(nt => nt.LangId)
                   .HasColumnName("Lang_Id")
                   .IsRequired();

            builder.Property(nt => nt.ImageAlt)
                   .HasColumnName("Img_alt");

            builder.HasOne(nt => nt.News)
                   .WithMany(n => n.Translations)
                   .HasForeignKey(nt => nt.NewsId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
