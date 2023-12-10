using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoleculesGui.Services;
using MoleculesGui.Services.OrderBook;
using Polly;
using Polly.Extensions.Http;

namespace MoleculesGui.common
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services,
                                                                    IWebAssemblyHostEnvironment environment)
        {
            services.RegisterHttpClient(environment);
            return services;
        }

        private static IServiceCollection RegisterHttpClient(this IServiceCollection services, 
                                                                    IWebAssemblyHostEnvironment environment) 
        {
            services.AddHttpClient<ICalcOrderServiceAgent, CalcOrderServiceAgent>(client =>
            {
                client.BaseAddress = new Uri(environment.GetApiBasePath());
            })
            .AddPolicyHandler(GetRetryPolicy());
            
            
            
            return services;       
        }


        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

    }
}
