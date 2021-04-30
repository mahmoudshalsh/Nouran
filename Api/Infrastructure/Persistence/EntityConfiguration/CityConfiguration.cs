using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nouran.Domain.Entities;

namespace Nouran.Infrastructure.Persistence.EntityConfigurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Title).HasMaxLength(50);
        }
    }
}