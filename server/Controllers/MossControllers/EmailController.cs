using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using SendGrid;
using SendGrid.Helpers.Mail;
using Cpdhelpdesk.Data;
using Cpdhelpdesk.Models;
using Cpdhelpdesk.Shared;

namespace Cpdhelpdesk.Controllers
{
    [ApiController]
    [Route("api/Email")]
    public class EmailController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AuthenticationconnContext _context;
        
        

        public EmailController(
            IConfiguration Configuration,
            IHttpContextAccessor HttpContextAccessor,
            AuthenticationconnContext context)
        {
            configuration = Configuration;
            httpContextAccessor = HttpContextAccessor;
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public object Get()
        {
            // Return only one Ticket
            //StringValues HelpDeskTicketGuidProperty;

            //string HelpDeskTicketGuid =
            //    (Request.Query.TryGetValue("HelpDeskTicketGuid",
            //    out HelpDeskTicketGuidProperty))
            //    ? HelpDeskTicketGuidProperty.ToString() : "";

            //var ExistingTicket = _context.HelpDeskTickets
            //    .Include(x => x.HelpDeskTicketDetails)
            //    .Where(x => x.TicketGUID == HelpDeskTicketGuid)
            //    .FirstOrDefault();

            //return ExistingTicket;
            return "mostafa test";
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<Task<string>> Post(
            HelpDeskEmail objHelpDeskEmail)
        {
            try
            {
                // Email settings
                SendGridMessage msg = new SendGridMessage();
                var apiKey = configuration["SENDGRID_APIKEY"];
                var senderEmail = configuration["SenderEmail"];
                var client = new SendGridClient(apiKey);

                var FromEmail = new EmailAddress(
                    senderEmail,
                    senderEmail
                    );

                // Format Email contents
                string strPlainTextContent =
                    $"{objHelpDeskEmail.EmailType}: " +
                    $"{GetHelpDeskTicketUrl(objHelpDeskEmail.id.ToString())}";

                string strHtmlContent =
                    $"<b>{objHelpDeskEmail.EmailType}:</b> ";
                strHtmlContent = strHtmlContent +
                    $"<a href='{ GetHelpDeskTicketUrl(objHelpDeskEmail.id.ToString()) }'>";
                strHtmlContent = strHtmlContent +
                    $"{GetHelpDeskTicketUrl(objHelpDeskEmail.id.ToString())}</a>";

                if (objHelpDeskEmail.EmailType == "Help Desk Ticket Created")
                {
                    msg = new SendGridMessage()
                    {
                        From = FromEmail,
                        Subject = objHelpDeskEmail.EmailType,
                        PlainTextContent = strPlainTextContent,
                        HtmlContent = strHtmlContent
                    };

                    // Created Email always goes to Administrator
                    // Send to senderEmail configured in appsettings.json
                    msg.AddTo(
                        new EmailAddress(senderEmail, objHelpDeskEmail.EmailType)
                        );
                }

                if (objHelpDeskEmail.EmailType == "Help Desk Ticket Updated")
                {
                    // Must pass a valid GUID 
                    // Get the existing record
                    if (_context.HelpDeskTickets
                        .Where(x => x.TicketGUID == objHelpDeskEmail.TicketGuid)
                        .FirstOrDefault() != null)
                    {
                        // See if the user is the Administrator
                        if (!this.User.IsInRole("Administrators"))
                        {
                            // Always send email to Administrator
                            objHelpDeskEmail.EmailAddresscc = objHelpDeskEmail.EmailAddresscc ;
                        }

                        msg = new SendGridMessage()
                        {
                            From = FromEmail,
                            Subject = objHelpDeskEmail.EmailType,
                            PlainTextContent = strPlainTextContent,
                            HtmlContent = strHtmlContent
                        };

                        // Send Email
                        msg.AddTo(new EmailAddress(
                            objHelpDeskEmail.EmailAddress,
                            objHelpDeskEmail.EmailType)
                            );
                        msg.AddCc(new EmailAddress(
                           objHelpDeskEmail.EmailAddresscc,
                           objHelpDeskEmail.EmailType)
                           );
                        msg.AddCc(new EmailAddress(
                           objHelpDeskEmail.EmailAddresasinto,
                           objHelpDeskEmail.EmailType)
                           );
                    }
                    else
                    {
                        await Task.FromResult("Error - Bad TicketGuid");
                    }
                }


                if (configuration["sendgridapi"].ToString() == "yes")
                {
                    await client.SendEmailAsync(msg);
                }

                await SendEmail(objHelpDeskEmail.EmailAddress, objHelpDeskEmail.EmailType, objHelpDeskEmail.EmailAddresscc, objHelpDeskEmail.EmailAddresasinto, strHtmlContent);
               
               

            }
            catch
            {
                // Could not send email
                // Perhaps SENDGRID_APIKEY not set in 
                // appsettings.json
            }

            return Task.FromResult("");
        }

        // Utility

        #region private string GetHelpDeskTicketUrl(string TicketGuid)
        private string GetHelpDeskTicketUrl(string TicketGuid)
        {
            var request = httpContextAccessor.HttpContext.Request;

            var host = request.Host.ToUriComponent();

            var pathBase = request.PathBase.ToUriComponent();

            return $@"{request.Scheme}://{host}{pathBase}/edit-i-help-desk-ticketwithdetails/{TicketGuid}";
            //i-edit-help-desk-ticket 
        }
        #endregion

        public async Task SendEmail(string userEmail, string subject,string ssemails, string ssemailsto, string text)
        {
            try { 
            var client = new System.Net.Mail.SmtpClient(configuration["smtp_server"]);
            if (configuration["authdefault"] == "yes")
            {
                client.UseDefaultCredentials = true;

            }
            else
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(configuration["useremailauth"], configuration["useremailauthpass"]);
            }
            client.Port = Int32.Parse(configuration["useremailauthport"]);
            var mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress(configuration["SenderEmail"]);
            mailMessage.To.Add(userEmail);
            mailMessage.Body = text;

            mailMessage.Subject = subject;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.CC.Add(ssemails);
                mailMessage.CC.Add(ssemailsto);
                client.EnableSsl =false ;
                if (configuration["EnableSsl"].ToString() == "yes")
                {
                    client.EnableSsl = true;
                }
            await client.SendMailAsync(mailMessage);
        }
            catch {
                await Task.FromResult("Error - Bad TicketGuid");

            }
        }

       
    }
}