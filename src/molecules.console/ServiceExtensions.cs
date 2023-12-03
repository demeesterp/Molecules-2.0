using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using molecules.console.App.Services;
using molecules.logger;
using molecules.core;
using molecules.data;

namespace molecules.console
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Add all services and middleware for Molecules API
        /// </summary>
        /// <param name="services">The application Services Collection</param>
        /// <returns>The modified services collection</returns>
        public static IServiceCollection AddMoleculesServices(this IServiceCollection services, IConfiguration configuration)
        {
           return services.AddApps()
                            .AddMoleculesLogging(ServiceLifetime.Transient, configuration.GetSection("MoleculesLoggerOptions"))
                            .AddCoreRepositories(ServiceLifetime.Transient)
                            .AddCoreServices(ServiceLifetime.Transient);
        }

        internal static IServiceCollection AddApps(this IServiceCollection services)
        {
            services.AddSingleton<CalcDeliveryServices>();
            services.AddSingleton<MoleculeReportService>();
            return services;
        }

        
    }
}
