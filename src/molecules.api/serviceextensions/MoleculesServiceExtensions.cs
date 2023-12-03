using Microsoft.Extensions.Configuration;
using molecules.core;
using molecules.data;
using molecules.logger;

namespace molecules.api.serviceextensions
{
    /// IServiceCollection extensions for Molecules API
    /// </summary>
    public static class MoleculesServiceExtensions
    {
        /// <summary>
        /// Add all services and middleware for Molecules API
        /// </summary>
        /// <param name="services">The application Services Collection</param>
        /// <param name="configuration">The configurations connected to logging</param>
        /// <returns>The modified services collection</returns>
        public static IServiceCollection AddMoleculesServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddCoreServices(ServiceLifetime.Scoped)
                                .AddCoreRepositories(ServiceLifetime.Scoped)
                                .AddMoleculesLogging(ServiceLifetime.Scoped, configuration.GetSection("MoleculesLoggerOptions"));
        }

        

       
    }
}
