using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Cpdhelpdesk.Models;
using Cpdhelpdesk.Models.Authenticationconn;
using Radzen;
using System.Net.Http.Json;
using System.Net.Http;
using Cpdhelpdesk.Shared;
using Microsoft.Extensions.Configuration;

using System.Security.Claims;

using Microsoft.AspNetCore.Components.Authorization;

namespace Cpdhelpdesk
{
    public partial class GlobalsService
    {
        [Inject]
        protected SecurityService Security { get; set; }

        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;
        public GlobalsService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}api/Email");
        }
        public  async Task SaveTicket(string TicketRequesterEmail,string TicketGUID,long id, string EmailAddresscc, string EmailAddresasinto)
        {

            

            // Send Email
            HelpDeskEmail objHelpDeskEmail = new HelpDeskEmail();
            objHelpDeskEmail.EmailType = "Help Desk Ticket Updated";
            objHelpDeskEmail.EmailAddress = TicketRequesterEmail;
            objHelpDeskEmail.TicketGuid = TicketGUID;
            objHelpDeskEmail.id = id;
            objHelpDeskEmail.EmailAddresscc = EmailAddresscc;
            objHelpDeskEmail.EmailAddresasinto = EmailAddresasinto;
            var myemail = Getuseremail();
            //await httpClient.PostAsJsonAsync("Email", objHelpDeskEmail);
           await httpClient.PostAsJsonAsync(baseUri, objHelpDeskEmail);

            return;
        }
        public async Task<string> Getuseremail()
        {

            
            var returnAddress = Security.Principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            

            return returnAddress;
        }
    }

   
}
