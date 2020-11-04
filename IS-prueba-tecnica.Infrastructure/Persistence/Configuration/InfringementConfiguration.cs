using IS_prueba_tecnica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS_prueba_tecnica.Infrastructure.Persistence.Configuration
{
    public class InfringementConfiguration : IEntityTypeConfiguration<Infringement>
    {
        public void Configure(EntityTypeBuilder<Infringement> builder)
        {
            builder.HasKey(d => d.Id);
        }
    }
}
