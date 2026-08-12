using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cpdhelpdesk.Data;

namespace Cpdhelpdesk
{
    public partial class ExportAuthenticationconnController : ExportController
    {
        private readonly AuthenticationconnContext context;
        public ExportAuthenticationconnController(AuthenticationconnContext context)
        {
            this.context = context;
        }

        [HttpGet("/export/Authenticationconn/customerswhatsapps/csv")]
        [HttpGet("/export/Authenticationconn/customerswhatsapps/csv(fileName='{fileName}')")]
        public FileStreamResult ExportCustomerswhatsappsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Customerswhatsapps, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/customerswhatsapps/excel")]
        [HttpGet("/export/Authenticationconn/customerswhatsapps/excel(fileName='{fileName}')")]
        public FileStreamResult ExportCustomerswhatsappsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Customerswhatsapps, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/devicecodes/csv")]
        [HttpGet("/export/Authenticationconn/devicecodes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDeviceCodesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.DeviceCodes, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/devicecodes/excel")]
        [HttpGet("/export/Authenticationconn/devicecodes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDeviceCodesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.DeviceCodes, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/emailswhatsappqeues/csv")]
        [HttpGet("/export/Authenticationconn/emailswhatsappqeues/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEmailsWhatsappQeuesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EmailsWhatsappQeues, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/emailswhatsappqeues/excel")]
        [HttpGet("/export/Authenticationconn/emailswhatsappqeues/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEmailsWhatsappQeuesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EmailsWhatsappQeues, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/emailswhatsappqeueemails/csv")]
        [HttpGet("/export/Authenticationconn/emailswhatsappqeueemails/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEmailsWhatsappQeueemailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EmailsWhatsappQeueemails, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/emailswhatsappqeueemails/excel")]
        [HttpGet("/export/Authenticationconn/emailswhatsappqeueemails/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEmailsWhatsappQeueemailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EmailsWhatsappQeueemails, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/empdepartments/csv")]
        [HttpGet("/export/Authenticationconn/empdepartments/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEmpDepartmentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EmpDepartments, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/empdepartments/excel")]
        [HttpGet("/export/Authenticationconn/empdepartments/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEmpDepartmentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EmpDepartments, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/empjoblists/csv")]
        [HttpGet("/export/Authenticationconn/empjoblists/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEmpJoblistsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EmpJoblists, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/empjoblists/excel")]
        [HttpGet("/export/Authenticationconn/empjoblists/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEmpJoblistsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EmpJoblists, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/helpdeskstatuses/csv")]
        [HttpGet("/export/Authenticationconn/helpdeskstatuses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportHelpDeskStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.HelpDeskStatuses, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/helpdeskstatuses/excel")]
        [HttpGet("/export/Authenticationconn/helpdeskstatuses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportHelpDeskStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.HelpDeskStatuses, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/helpdesktickets/csv")]
        [HttpGet("/export/Authenticationconn/helpdesktickets/csv(fileName='{fileName}')")]
        public FileStreamResult ExportHelpDeskTicketsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.HelpDeskTickets, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/helpdesktickets/excel")]
        [HttpGet("/export/Authenticationconn/helpdesktickets/excel(fileName='{fileName}')")]
        public FileStreamResult ExportHelpDeskTicketsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.HelpDeskTickets, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/helpdeskticketdetails/csv")]
        [HttpGet("/export/Authenticationconn/helpdeskticketdetails/csv(fileName='{fileName}')")]
        public FileStreamResult ExportHelpDeskTicketDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.HelpDeskTicketDetails, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/helpdeskticketdetails/excel")]
        [HttpGet("/export/Authenticationconn/helpdeskticketdetails/excel(fileName='{fileName}')")]
        public FileStreamResult ExportHelpDeskTicketDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.HelpDeskTicketDetails, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/localizationresources/csv")]
        [HttpGet("/export/Authenticationconn/localizationresources/csv(fileName='{fileName}')")]
        public FileStreamResult ExportLocalizationResourcesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.LocalizationResources, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/localizationresources/excel")]
        [HttpGet("/export/Authenticationconn/localizationresources/excel(fileName='{fileName}')")]
        public FileStreamResult ExportLocalizationResourcesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.LocalizationResources, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/localizationresourcetranslations/csv")]
        [HttpGet("/export/Authenticationconn/localizationresourcetranslations/csv(fileName='{fileName}')")]
        public FileStreamResult ExportLocalizationResourceTranslationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.LocalizationResourceTranslations, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/localizationresourcetranslations/excel")]
        [HttpGet("/export/Authenticationconn/localizationresourcetranslations/excel(fileName='{fileName}')")]
        public FileStreamResult ExportLocalizationResourceTranslationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.LocalizationResourceTranslations, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/locationlists/csv")]
        [HttpGet("/export/Authenticationconn/locationlists/csv(fileName='{fileName}')")]
        public FileStreamResult ExportLocationListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.LocationLists, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/locationlists/excel")]
        [HttpGet("/export/Authenticationconn/locationlists/excel(fileName='{fileName}')")]
        public FileStreamResult ExportLocationListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.LocationLists, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/mrtcontrollernames/csv")]
        [HttpGet("/export/Authenticationconn/mrtcontrollernames/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMrtcontrollerNamesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MrtcontrollerNames, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/mrtcontrollernames/excel")]
        [HttpGet("/export/Authenticationconn/mrtcontrollernames/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMrtcontrollerNamesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MrtcontrollerNames, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/persistedgrants/csv")]
        [HttpGet("/export/Authenticationconn/persistedgrants/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPersistedGrantsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PersistedGrants, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/persistedgrants/excel")]
        [HttpGet("/export/Authenticationconn/persistedgrants/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPersistedGrantsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PersistedGrants, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/servicecatglists/csv")]
        [HttpGet("/export/Authenticationconn/servicecatglists/csv(fileName='{fileName}')")]
        public FileStreamResult ExportServiceCatglistsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ServiceCatglists, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/servicecatglists/excel")]
        [HttpGet("/export/Authenticationconn/servicecatglists/excel(fileName='{fileName}')")]
        public FileStreamResult ExportServiceCatglistsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ServiceCatglists, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/serviceslists/csv")]
        [HttpGet("/export/Authenticationconn/serviceslists/csv(fileName='{fileName}')")]
        public FileStreamResult ExportServicesListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.ServicesLists, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/serviceslists/excel")]
        [HttpGet("/export/Authenticationconn/serviceslists/excel(fileName='{fileName}')")]
        public FileStreamResult ExportServicesListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.ServicesLists, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/sitecontents/csv")]
        [HttpGet("/export/Authenticationconn/sitecontents/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSiteContentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SiteContents, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/sitecontents/excel")]
        [HttpGet("/export/Authenticationconn/sitecontents/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSiteContentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SiteContents, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/smslists/csv")]
        [HttpGet("/export/Authenticationconn/smslists/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSmsListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SmsLists, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/smslists/excel")]
        [HttpGet("/export/Authenticationconn/smslists/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSmsListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SmsLists, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/smsbrands/csv")]
        [HttpGet("/export/Authenticationconn/smsbrands/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSmsbrandsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Smsbrands, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/smsbrands/excel")]
        [HttpGet("/export/Authenticationconn/smsbrands/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSmsbrandsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Smsbrands, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/smscatids/csv")]
        [HttpGet("/export/Authenticationconn/smscatids/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSmscatidsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Smscatids, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/smscatids/excel")]
        [HttpGet("/export/Authenticationconn/smscatids/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSmscatidsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Smscatids, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/smsqueuelists/csv")]
        [HttpGet("/export/Authenticationconn/smsqueuelists/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSmsqueueListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SmsqueueLists, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/smsqueuelists/excel")]
        [HttpGet("/export/Authenticationconn/smsqueuelists/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSmsqueueListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SmsqueueLists, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/smsqueuelistds/csv")]
        [HttpGet("/export/Authenticationconn/smsqueuelistds/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSmsqueueListdsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SmsqueueListds, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/smsqueuelistds/excel")]
        [HttpGet("/export/Authenticationconn/smsqueuelistds/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSmsqueueListdsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SmsqueueListds, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/softwaremodulescatlists/csv")]
        [HttpGet("/export/Authenticationconn/softwaremodulescatlists/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSoftwareModulescatlistsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SoftwareModulescatlists, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/softwaremodulescatlists/excel")]
        [HttpGet("/export/Authenticationconn/softwaremodulescatlists/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSoftwareModulescatlistsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SoftwareModulescatlists, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/tblpages/csv")]
        [HttpGet("/export/Authenticationconn/tblpages/csv(fileName='{fileName}')")]
        public FileStreamResult ExportTblPagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.TblPages, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/tblpages/excel")]
        [HttpGet("/export/Authenticationconn/tblpages/excel(fileName='{fileName}')")]
        public FileStreamResult ExportTblPagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.TblPages, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/telphonuserslists/csv")]
        [HttpGet("/export/Authenticationconn/telphonuserslists/csv(fileName='{fileName}')")]
        public FileStreamResult ExportTelphonUsersListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.TelphonUsersLists, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/telphonuserslists/excel")]
        [HttpGet("/export/Authenticationconn/telphonuserslists/excel(fileName='{fileName}')")]
        public FileStreamResult ExportTelphonUsersListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.TelphonUsersLists, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/ticketrequesteruserslists/csv")]
        [HttpGet("/export/Authenticationconn/ticketrequesteruserslists/csv(fileName='{fileName}')")]
        public FileStreamResult ExportTicketRequesterUsersListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.TicketRequesterUsersLists, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/ticketrequesteruserslists/excel")]
        [HttpGet("/export/Authenticationconn/ticketrequesteruserslists/excel(fileName='{fileName}')")]
        public FileStreamResult ExportTicketRequesterUsersListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.TicketRequesterUsersLists, Request.Query), fileName);
        }
        [HttpGet("/export/Authenticationconn/useraudits/csv")]
        [HttpGet("/export/Authenticationconn/useraudits/csv(fileName='{fileName}')")]
        public FileStreamResult ExportUserAuditsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.UserAudits, Request.Query), fileName);
        }

        [HttpGet("/export/Authenticationconn/useraudits/excel")]
        [HttpGet("/export/Authenticationconn/useraudits/excel(fileName='{fileName}')")]
        public FileStreamResult ExportUserAuditsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.UserAudits, Request.Query), fileName);
        }
    }
}
