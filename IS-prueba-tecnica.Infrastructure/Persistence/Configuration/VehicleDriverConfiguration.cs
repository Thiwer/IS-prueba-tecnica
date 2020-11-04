using IS_prueba_tecnica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IS_prueba_tecnica.Infrastructure.Persistence.Configuration
{
    public class VehicleDriverConfiguration : IEntityTypeConfiguration<VehicleDriver>
    {
        public void Configure(EntityTypeBuilder<VehicleDriver> builder)
        {
            builder.HasKey(vd => new { vd.VehicleMatricula, vd.DriverDni });

            builder
                .HasOne(vd => vd.Vehicle)
                .WithMany(v => v.VehicleDrivers)
                .HasForeignKey(vd => vd.VehicleMatricula)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(vd => vd.Driver)
                .WithMany(d => d.VehicleDrivers)
                .HasForeignKey(vd => vd.DriverDni)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
