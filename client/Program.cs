using System;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Authorization;
using Cpdhelpdesk.Authentication;
using Radzen;

namespace Cpdhelpdesk
{
    public partial class Program
    {
        static partial void OnConfigureBuilder(WebAssemblyHostBuilder builder);

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<Client.App>("app");
            builder.RootComponents.Add<Microsoft.AspNetCore.Components.Web.HeadOutlet>("head::after");
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();
            builder.Services.AddScoped<GlobalsService>();

            builder.Services.AddScoped<SecurityService>();

            builder.Services.AddHttpClient("Cpdhelpdesk.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddScoped<AuthenticationStateProvider>(sp => new WindowsAuthenticationStateProvider(builder.HostEnvironment.BaseAddress, sp.GetRequiredService<IJSRuntime>()));

            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Cpdhelpdesk.ServerAPI"));
            builder.Services.AddApiAuthorization();

            builder.Services.AddScoped<AuthenticationconnService>();

            builder.Services.AddLocalization();

            OnConfigureBuilder(builder);

            await builder.Build().RunAsync();
        }
    }
}
