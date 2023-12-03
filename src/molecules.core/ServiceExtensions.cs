using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using molecules.core.factories;
using molecules.core.factories.calcinput;
using molecules.core.factories.calcmolecule;
using molecules.core.factories.calcorder;
using molecules.core.factories.reports;
using molecules.core.services.calcdelivery;
using molecules.core.services.calcmolecule;
using molecules.core.services.calcorders;
using molecules.core.services.reports;
using molecules.core.services.validators;
using molecules.core.services.validators.validation.service;

namespace molecules.core
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, ServiceLifetime serviceLifetime)
        {
            services.AddValidatorsFromAssemblyContaining<CreateCalcOrderValidator>(serviceLifetime);


            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton<ICalcOrderServiceValidations, CalcOrderServiceValidations>();
                    services.AddSingleton<ICalcOrderFactory, CalcOrderFactory>();
                    services.AddSingleton<ICalcOrderService, CalcOrderService>();


                    services.AddSingleton<ICalcOrderItemServiceValidations, CalcOrderItemServiceValidations>();
                    services.AddSingleton<ICalcOrderItemFactory, CalcOrderItemFactory>();
                    services.AddSingleton<ICalcOrderItemService, CalcOrderItemService>();


                    services.AddSingleton<IGmsCalcInputFactory, GmsCalcInputFactory>();
                    services.AddSingleton<IMoleculeFromGmsFactory, MoleculeFromGmsFactory>();
                    services.AddSingleton<ICalcDeliveryService, CalcDeliveryService>();


                    services.AddSingleton<ICalcMoleculeFactory, CalcMoleculeFactory>();
                    services.AddSingleton<ICalcMoleculeService, CalcMoleculeService>();

                    services.AddSingleton<IMoleculeReportFactory, MoleculeReportFactory>();
                    services.AddSingleton<IMoleculeReportService, MoleculeReportService>();
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped<ICalcOrderServiceValidations, CalcOrderServiceValidations>();
                    services.AddScoped<ICalcOrderFactory, CalcOrderFactory>();
                    services.AddScoped<ICalcOrderService, CalcOrderService>();


                    services.AddScoped<ICalcOrderItemServiceValidations, CalcOrderItemServiceValidations>();
                    services.AddScoped<ICalcOrderItemFactory, CalcOrderItemFactory>();
                    services.AddScoped<ICalcOrderItemService, CalcOrderItemService>();


                    services.AddScoped<IGmsCalcInputFactory, GmsCalcInputFactory>();
                    services.AddScoped<IMoleculeFromGmsFactory, MoleculeFromGmsFactory>();
                    services.AddScoped<ICalcDeliveryService, CalcDeliveryService>();


                    services.AddScoped<ICalcMoleculeFactory, CalcMoleculeFactory>();
                    services.AddScoped<ICalcMoleculeService, CalcMoleculeService>();

                    services.AddScoped<IMoleculeReportFactory, MoleculeReportFactory>();
                    services.AddScoped<IMoleculeReportService, MoleculeReportService>();
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient<ICalcOrderServiceValidations, CalcOrderServiceValidations>();
                    services.AddTransient<ICalcOrderFactory, CalcOrderFactory>();
                    services.AddTransient<ICalcOrderService, CalcOrderService>();


                    services.AddTransient<ICalcOrderItemServiceValidations, CalcOrderItemServiceValidations>();
                    services.AddTransient<ICalcOrderItemFactory, CalcOrderItemFactory>();
                    services.AddTransient<ICalcOrderItemService, CalcOrderItemService>();


                    services.AddTransient<IGmsCalcInputFactory, GmsCalcInputFactory>();
                    services.AddTransient<IMoleculeFromGmsFactory, MoleculeFromGmsFactory>();
                    services.AddTransient<ICalcDeliveryService, CalcDeliveryService>();


                    services.AddTransient<ICalcMoleculeFactory, CalcMoleculeFactory>();
                    services.AddTransient<ICalcMoleculeService, CalcMoleculeService>();

                    services.AddTransient<IMoleculeReportFactory, MoleculeReportFactory>();
                    services.AddTransient<IMoleculeReportService, MoleculeReportService>();
                    break;
            }


            

            return services;

        }
    }
}
