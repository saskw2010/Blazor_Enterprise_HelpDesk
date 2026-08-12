using System;
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
using System.Globalization;

namespace Cpdhelpdesk
{




    public partial class Program
    {

        static partial void OnConfigureBuilder(WebAssemblyHostBuilder builder)
        {
            //builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            ////builder.Services.AddJsonLocalization(options => options.ResourcesPath = "Resources");
            //builder.Services.AddJsonLocalization();
            ////OnConfigureBuildermostafaAsync(builder);

            // See: https://docs.microsoft.com/en-us/aspnet/core/security/blazor/webassembly/additional-scenarios?view=aspnetcore-3.1#unauthenticated-or-unauthorized-web-api-requests-in-an-app-with-a-secure-default-client
            // builder.Services.AddHttpClient("ServerAPI.NoAuthenticationClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));


        }


    //    builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");

    //        OnConfigureBuilder(builder);

    //    // await builder.Build().RunAsync();
    //    var host = builder.Build();
    //    var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
    //    var result = await jsInterop.InvokeAsync<string>("Radzen.getCulture");
    //        // await JSRuntime.InvokeAsync<string>("Radzen.getCulture");
    //        if (result != null)
    //        {
    //            // Set the culture from culture switcher
    //            var culture = new CultureInfo(result);
    //    CultureInfo.DefaultThreadCurrentCulture = culture;
    //            CultureInfo.DefaultThreadCurrentUICulture = culture;
    //        }
    //await host.RunAsync();


}



    }

