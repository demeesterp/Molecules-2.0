using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoleculesGui.common;

namespace MoleculesGui.Services
{
    public static class EnvironmentSettingsService 
    {
        public static string GetApiBasePath(this IWebAssemblyHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.Environment == Environments.Development.ToString())
            {
                return "https://localhost:44376/";
            }
            throw new NotImplementedException($"Environment {hostingEnvironment.Environment} is not supported");
        }
    }
}
