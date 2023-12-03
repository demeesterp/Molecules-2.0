using Microsoft.Extensions.DependencyInjection;
using molecules.core.common.interfaces.repositories;
using molecules.data.repositories;

namespace molecules.data
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddCoreRepositories(this IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton<ICalcOrderRepository, CalcOrderRepository>();
                    services.AddSingleton<ICalcOrderItemRepository, CalcOrderItemRepository>();
                    services.AddSingleton<IMoleculeRepository, MoleculeRepository>();
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped<ICalcOrderRepository, CalcOrderRepository>();
                    services.AddScoped<ICalcOrderItemRepository, CalcOrderItemRepository>();
                    services.AddScoped<IMoleculeRepository, MoleculeRepository>();
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient<ICalcOrderRepository, CalcOrderRepository>();
                    services.AddTransient<ICalcOrderItemRepository, CalcOrderItemRepository>();
                    services.AddTransient<IMoleculeRepository, MoleculeRepository>();
                    break;
            }
            return services;
        }
    }
}
