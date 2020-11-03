using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;

namespace IS_prueba_tecnica.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
