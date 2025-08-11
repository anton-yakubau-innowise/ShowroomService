using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowroomService.Domain.Entities;

namespace ShowroomService.Infrastructure.Persistence.Configuration
{
    public class ShowroomEntityTypeConfiguration : IEntityTypeConfiguration<Showroom>
    {
        public void Configure(EntityTypeBuilder<Showroom> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Alias)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Country)
                .IsRequired()
                .HasMaxLength(100);
                
            builder.Property(s => s.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);
                
            builder.Property(s => s.OperatingHours)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(50);
        }
    }
}