using IS_prueba_tecnica.Application.Common.Interfaces;
using IS_prueba_tecnica.Domain.Common;
using IS_prueba_tecnica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Infrastructure.Persistence
{
    public class PruebaTecnicaDbContext : DbContext, IPruebaTecnicaDbContext
    {
        private readonly IDateTime _dateTime;


        public DbSet<Vehicle> Vehicles { get; set; }


        public PruebaTecnicaDbContext(DbContextOptions options, IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var dateTimeUtcNow = _dateTime.Now;
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Created = dateTimeUtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModified = dateTimeUtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public DbConnection GetDbConnection() => Database.GetDbConnection();
    }
}
