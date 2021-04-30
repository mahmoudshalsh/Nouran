using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nouran.Domain.Entities;

namespace Nouran.Infrastructure.Persistence.EntityConfigurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasKey(e=>e.Id);
            builder.Property(e=>e.Title).HasMaxLength(50);
        }
    }
}