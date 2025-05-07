using Menofia_Portal.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Monofia_Portal.Infrastructure.Configurations
{
    public class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.ToTable("ContactUs");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(c => c.PhoneNumber)
                   .IsRequired();

            builder.Property(c => c.CreatedAt)
                   .IsRequired();
        }
    }
}
