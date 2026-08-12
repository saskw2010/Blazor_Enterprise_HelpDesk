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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        partial void OnConfigureServices(IServiceCollection services);

        partial void OnConfiguringServices(IServiceCollection services);

        public void ConfigureServices(IServiceCollection services)
        {
            OnConfiguringServices(services);

            services.AddHttpContextAccessor();
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAny",
                    x =>
                    {
                        x.AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(isOriginAllowed: _ => true)
                        .AllowCredentials();
                    });
            });
            var oDataBuilder = new ODataConventionModelBuilder();

            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>("Customerswhatsapps");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.DeviceCode>("DeviceCodes");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>("EmailsWhatsappQeues");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>("EmailsWhatsappQeueemails");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment>("EmpDepartments");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist>("EmpJoblists");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus>("HelpDeskStatuses");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>("HelpDeskTickets");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail>("HelpDeskTicketDetails");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource>("LocalizationResources");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation>("LocalizationResourceTranslations");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.LocationList>("LocationLists");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName>("MrtcontrollerNames");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.PersistedGrant>("PersistedGrants");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist>("ServiceCatglists");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.ServicesList>("ServicesLists");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.SiteContent>("SiteContents");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.SmsList>("SmsLists");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.Smsbrand>("Smsbrands");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.Smscatid>("Smscatids");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>("SmsqueueLists");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>("SmsqueueListds");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist>("SoftwareModulescatlists");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.TblPage>("TblPages");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList>("TelphonUsersLists");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList>("TicketRequesterUsersLists");
            oDataBuilder.EntitySet<Cpdhelpdesk.Models.Authenticationconn.UserAudit>("UserAudits");

            this.OnConfigureOData(oDataBuilder);


            var model = oDataBuilder.GetEdmModel();
            services.AddControllers().AddOData(opt => { 
              opt.AddRouteComponents("odata/authenticationconn", model).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
            });

            
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            }).AddApiAuthorization();
            services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
            services.AddScoped<SecurityService>();

            services.AddDbContext<Cpdhelpdesk.Data.AuthenticationconnContext>(options =>
            {
              options.UseSqlServer(Configuration.GetConnectionString("authenticationconnConnection"));
            });

            services.AddRazorPages();
            services.AddLocalization();

            var supportedCultures = new[]
            {
                new System.Globalization.CultureInfo("ar-KW"),
                new System.Globalization.CultureInfo("en-US"),
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ar-KW");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });


            OnConfigureServices(services);
        }

        partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env);
        partial void OnConfigureOData(ODataConventionModelBuilder builder);
        partial void OnConfiguring(IApplicationBuilder app, IWebHostEnvironment env);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            OnConfiguring(app, env);

            var supportedCultures = new[]
            {
                new System.Globalization.CultureInfo("ar-KW"),
                new System.Globalization.CultureInfo("en-US"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ar-KW"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
            {
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.Use((ctx, next) =>
                {
                    ctx.Request.Scheme = "https";
                    return next();
                });
            }
            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IServiceProvider provider = app.ApplicationServices.GetRequiredService<IServiceProvider>();
            app.UseCors("AllowAny");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            OnConfigure(app, env);
        }
    }


}
