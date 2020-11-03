using IS_prueba_tecnica.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Infrastructure.Persistence
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PruebaTecnicaDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<PruebaTecnicaDbContext>>(), new DateTimeService()))
            {
                // Look for any board games.
                if (context.Drivers.Any())
                {
                    return;   // Data was already seeded
                }

                context.SaveChanges();
            }
        }
    }
}
