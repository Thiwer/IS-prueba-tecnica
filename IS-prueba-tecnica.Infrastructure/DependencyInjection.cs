using IS_prueba_tecnica.Application.Common.Interfaces;
using IS_prueba_tecnica.Application.Common.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IS_prueba_tecnica.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("FormulariosConnection");
            services.AddTransient<IDbConnection>(sp => new SqlConnection(dbConnectionString));
            services.AddDbContext<PruebaTecnicaDbContext>(options =>
            {
                options.UseSqlServer(
                    dbConnectionString,
                    options =>
                    {
                        options.MigrationsAssembly(typeof(SurveyDbContext).Assembly.FullName);
                    })
                    .EnableSensitiveDataLogging();
            });

            services.AddScoped<IPruebaTecnicaDbContext>(provider => provider.GetService<PruebaTecnicaDbContext>());

            services.AddScoped<IUnitOfWork, UnitOfWorkContainer>();

            services.AddSingleton<IDateTime, DateTimeService>();

            return services;
        }
    }
}
