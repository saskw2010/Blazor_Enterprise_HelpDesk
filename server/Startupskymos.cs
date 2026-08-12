using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Cpdhelpdesk.Data;

using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
namespace Cpdhelpdesk
{
    public partial class Startup
    {

        private bool _createNewRecordWhenLocalisedStringDoesNotExist = false;
        public class ThemeState
        {
            public string CurrentTheme { get; set; } = "default";
        }

        //stating changing 
        partial void OnConfiguring(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _createNewRecordWhenLocalisedStringDoesNotExist = true;
            }
        }
    partial void OnConfigureServices(IServiceCollection services)
        {

            // for oracle connections
            //var connStr = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.20.33)(PORT = 1521)) (CONNECT_DATA=(SID=xe)));User Id=system;Password=jaber;";
            //Services.Add(new ServiceDescriptor(typeof(OracleDBContext), new OracleDBContext(connStr)));



            //DI 
            // services.AddSingleton<IStringLocalizerFactory, EFStringLocalizerFactory>();
            //services.AddTransient(typeof(IStringLocalizer<>), typeof(EFStringLocalizer<>));
            //var localizer = EFStringLocalizerFactory.Create(null);



           // services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
            //services.AddLocalization(opts => { opts.ResourcesPath = Environment.CurrentDirectory + "\\Resources"; });

            //services.AddBlazoredLocalStorage();
            //var sqlConnectionString = Configuration.GetConnectionString("authenticationconnConnection");
            ////Configuration["DbStringLocalizer:ConnectionString"];




            //var supportedCultures = new[]
            //{
            //    new System.Globalization.CultureInfo("ar-KW"),
            //    new System.Globalization.CultureInfo("en-US"),
            //    new System.Globalization.CultureInfo("fr-CA"),
            //};






        }

        partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseDbLocalizationProvider();
            //app.UseDbLocalizationProviderAdminUI();
            //app.UseDbLocalizationClientsideProvider();

            

            
        }


}
}
