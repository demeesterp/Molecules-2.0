using FluentValidation;
using molecule.core.common.interfaces.repositories;
using molecules.core.factories.calcinput;
using molecules.core.factories.calcmolecule;
using molecules.core.factories.calcorder;
using molecules.core.factories.reports;
using molecules.core.factories;
using molecules.core.services.calcdelivery;
using molecules.core.services.calcmolecule;
using molecules.core.services.calcorders;
using molecules.core.services.reports;
using molecules.core.services.validators.validation.service;
using molecules.core.services.validators;
using molecules.data.repositories;
using Serilog.Events;
using Serilog;

namespace molecules.api.serviceextensions
{
    /// IServiceCollection extensions for Molecules API
    /// </summary>
    public static class MoleculeApiServiceExtensions
    {
        /// <summary>
        /// Add all services and middleware for Molecules API
        /// </summary>
        /// <param name="services">The application Services Collection</param>
        /// <returns>The modified services collection</returns>
        public static IServiceCollection AddMoleculesServices(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddCoreServices();

            return services;
        }

        internal static void AddCoreServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateCalcOrderValidator>();

            services.AddScoped<ICalcOrderServiceValidations, CalcOrderServiceValidations>();
            services.AddScoped<ICalcOrderFactory, CalcOrderFactory>();
            services.AddScoped<ICalcOrderService, CalcOrderService>();
            services.AddScoped<ICalcOrderRepository, CalcOrderRepository>();

            services.AddScoped<ICalcOrderItemServiceValidations, CalcOrderItemServiceValidations>();
            services.AddScoped<ICalcOrderItemFactory, CalcOrderItemFactory>();
            services.AddScoped<ICalcOrderItemService, CalcOrderItemService>();
            services.AddScoped<ICalcOrderItemRepository, CalcOrderItemRepository>();

            services.AddScoped<IGmsCalcInputFactory, GmsCalcInputFactory>();
            services.AddScoped<IMoleculeFromGmsFactory, MoleculeFromGmsFactory>();
            services.AddScoped<ICalcDeliveryService, CalcDeliveryService>();

            services.AddScoped<IMoleculeRepository, MoleculeRepository>();
            services.AddScoped<ICalcMoleculeFactory, CalcMoleculeFactory>();
            services.AddScoped<ICalcMoleculeService, CalcMoleculeService>();

            services.AddScoped<IMoleculeReportFactory, MoleculeReportFactory>();
            services.AddScoped<IMoleculeReportService, MoleculeReportService>();

        }

        internal static void AddLogging(this IServiceCollection services)
        {
            var logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                                .WriteTo.File(path: "C:\\Data\\Logs\\log.txt",
                                                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                                                rollingInterval: RollingInterval.Day,
                                                restrictedToMinimumLevel: LogEventLevel.Information)
                                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug)
                                .CreateLogger();
        }
    }
}
