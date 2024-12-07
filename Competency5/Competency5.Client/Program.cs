using Competency5.Client;
using Competency5.Client.Data.DAL;
using Entities.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Competency5.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddAuthorizationCore();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

            // Add DAL
            builder.Services.AddTransient<IContactsDAL, ClientContactsDAL>();

            // HTTP Client
            builder.Services.AddScoped(http => new HttpClient {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
            });

            await builder.Build().RunAsync();
        }
    }
}
