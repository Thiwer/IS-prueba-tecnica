using IS_prueba_tecnica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Infrastructure.Persistence.Configuration
{
    public class InfringementVehicleDriverConfiguration : IEntityTypeConfiguration<InfringementVehicleDriver>
    {
        public void Configure(EntityTypeBuilder<InfringementVehicleDriver> builder)
        {
            builder.HasKey(ivd => ivd.Id);

            builder
                .Property(ivd => ivd.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(ivd => ivd.VehicleDriver)
                .WithMany(vd => vd.InfringementVehicleDrivers)
                .HasForeignKey(ivd => new { ivd.VehicleMatricula, ivd.DriverDni })
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ivd => ivd.Infringement)
                .WithMany(i => i.InfringementVehicleDrivers)
                .HasForeignKey(ivd => ivd.InfringementId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
