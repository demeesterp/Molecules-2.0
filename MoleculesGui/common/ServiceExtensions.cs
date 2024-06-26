﻿using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoleculesGui.services.molecules;
using MoleculesGui.Services;
using MoleculesGui.Services.OrderBook;
using MoleculesGui.shared.error;
using MoleculesGui.shared.httpclient_helper;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System.Net;

namespace MoleculesGui.common
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services,
                                                                    IWebAssemblyHostEnvironment environment)
        {
           return services.RegisterServices().RegisterHttpClient(environment);
        }

        private static IServiceCollection RegisterHttpClient(this IServiceCollection services, 
                                                                    IWebAssemblyHostEnvironment environment) 
        {
            // Molecule orders service agent
            services.AddHttpClient<ICalcOrderServiceAgent, CalcOrderServiceAgent>(client =>
            {
                client.BaseAddress = new Uri(environment.GetApiBasePath());
            })
            .AddPolicyHandler(GetRetryPolicy());
            
            // Molecule service agents
            services.AddHttpClient<IMoleculesServiceAgent, MoleculesServiceAgent>(client =>
            {
                client.BaseAddress = new Uri(environment.GetApiBasePath());
            })
           .AddPolicyHandler(GetRetryPolicy());

            // Molecule report service agents
            services.AddHttpClient<IMoleculesReportServiceAgent, MoleculesReportServiceAgent>(client =>
            {
                client.BaseAddress = new Uri(environment.GetApiBasePath());
            })
           .AddPolicyHandler(GetRetryPolicy());
            
            return services;       
        }


        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<MoleculesHttpClient>();
            services.AddSingleton<ErrorHandlingService>();
            services.AddSingleton<ICalcOrderServiceAgent, CalcOrderServiceAgent>();
            services.AddSingleton<IMoleculesServiceAgent, MoleculesServiceAgent>();
            services.AddSingleton<IMoleculesAnalysisService, MoleculesAnalysisService>();
            services.AddSingleton<IMoleculesReportServiceAgent, MoleculesReportServiceAgent>();
            return services;
        }


        private static AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

    }
}
