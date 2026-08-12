
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using Cpdhelpdesk.Models.Authenticationconn;

namespace Cpdhelpdesk
{
    public partial class AuthenticationconnService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;
        public AuthenticationconnService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/authenticationconn/");
        }

        public async System.Threading.Tasks.Task ExportCustomerswhatsappsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/customerswhatsapps/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/customerswhatsapps/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportCustomerswhatsappsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/customerswhatsapps/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/customerswhatsapps/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetCustomerswhatsapps(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>> GetCustomerswhatsapps(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Customerswhatsapps");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCustomerswhatsapps(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>>(response);
        }
        partial void OnCreateCustomerswhatsapp(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp> CreateCustomerswhatsapp(Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp customerswhatsapp = default(Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp))
        {
            var uri = new Uri(baseUri, $"Customerswhatsapps");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(customerswhatsapp), Encoding.UTF8, "application/json");

            OnCreateCustomerswhatsapp(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>(response);
        }

        public async System.Threading.Tasks.Task ExportDeviceCodesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/devicecodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/devicecodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDeviceCodesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/devicecodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/devicecodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetDeviceCodes(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.DeviceCode>> GetDeviceCodes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"DeviceCodes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeviceCodes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.DeviceCode>>(response);
        }
        partial void OnCreateDeviceCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.DeviceCode> CreateDeviceCode(Cpdhelpdesk.Models.Authenticationconn.DeviceCode deviceCode = default(Cpdhelpdesk.Models.Authenticationconn.DeviceCode))
        {
            var uri = new Uri(baseUri, $"DeviceCodes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(deviceCode), Encoding.UTF8, "application/json");

            OnCreateDeviceCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.DeviceCode>(response);
        }

        public async System.Threading.Tasks.Task ExportEmailsWhatsappQeuesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/emailswhatsappqeues/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/emailswhatsappqeues/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEmailsWhatsappQeuesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/emailswhatsappqeues/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/emailswhatsappqeues/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetEmailsWhatsappQeues(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>> GetEmailsWhatsappQeues(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"EmailsWhatsappQeues");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmailsWhatsappQeues(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>>(response);
        }
        partial void OnCreateEmailsWhatsappQeue(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue> CreateEmailsWhatsappQeue(Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue emailsWhatsappQeue = default(Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue))
        {
            var uri = new Uri(baseUri, $"EmailsWhatsappQeues");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(emailsWhatsappQeue), Encoding.UTF8, "application/json");

            OnCreateEmailsWhatsappQeue(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>(response);
        }

        public async System.Threading.Tasks.Task ExportEmailsWhatsappQeueemailsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/emailswhatsappqeueemails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/emailswhatsappqeueemails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEmailsWhatsappQeueemailsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/emailswhatsappqeueemails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/emailswhatsappqeueemails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetEmailsWhatsappQeueemails(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>> GetEmailsWhatsappQeueemails(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"EmailsWhatsappQeueemails");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmailsWhatsappQeueemails(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>>(response);
        }
        partial void OnCreateEmailsWhatsappQeueemail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail> CreateEmailsWhatsappQeueemail(Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail emailsWhatsappQeueemail = default(Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail))
        {
            var uri = new Uri(baseUri, $"EmailsWhatsappQeueemails");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(emailsWhatsappQeueemail), Encoding.UTF8, "application/json");

            OnCreateEmailsWhatsappQeueemail(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>(response);
        }

        public async System.Threading.Tasks.Task ExportEmpDepartmentsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/empdepartments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/empdepartments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEmpDepartmentsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/empdepartments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/empdepartments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetEmpDepartments(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment>> GetEmpDepartments(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"EmpDepartments");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmpDepartments(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment>>(response);
        }
        partial void OnCreateEmpDepartment(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment> CreateEmpDepartment(Cpdhelpdesk.Models.Authenticationconn.EmpDepartment empDepartment = default(Cpdhelpdesk.Models.Authenticationconn.EmpDepartment))
        {
            var uri = new Uri(baseUri, $"EmpDepartments");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(empDepartment), Encoding.UTF8, "application/json");

            OnCreateEmpDepartment(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment>(response);
        }

        public async System.Threading.Tasks.Task ExportEmpJoblistsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/empjoblists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/empjoblists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportEmpJoblistsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/empjoblists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/empjoblists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetEmpJoblists(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist>> GetEmpJoblists(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"EmpJoblists");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmpJoblists(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist>>(response);
        }
        partial void OnCreateEmpJoblist(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist> CreateEmpJoblist(Cpdhelpdesk.Models.Authenticationconn.EmpJoblist empJoblist = default(Cpdhelpdesk.Models.Authenticationconn.EmpJoblist))
        {
            var uri = new Uri(baseUri, $"EmpJoblists");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(empJoblist), Encoding.UTF8, "application/json");

            OnCreateEmpJoblist(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist>(response);
        }

        public async System.Threading.Tasks.Task ExportHelpDeskStatusesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/helpdeskstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/helpdeskstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportHelpDeskStatusesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/helpdeskstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/helpdeskstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetHelpDeskStatuses(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus>> GetHelpDeskStatuses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"HelpDeskStatuses");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHelpDeskStatuses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus>>(response);
        }
        partial void OnCreateHelpDeskStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus> CreateHelpDeskStatus(Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus helpDeskStatus = default(Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus))
        {
            var uri = new Uri(baseUri, $"HelpDeskStatuses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(helpDeskStatus), Encoding.UTF8, "application/json");

            OnCreateHelpDeskStatus(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus>(response);
        }

        public async System.Threading.Tasks.Task ExportHelpDeskTicketsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/helpdesktickets/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/helpdesktickets/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportHelpDeskTicketsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/helpdesktickets/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/helpdesktickets/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetHelpDeskTickets(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>> GetHelpDeskTickets(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"HelpDeskTickets");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHelpDeskTickets(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>>(response);
        }
        partial void OnCreateHelpDeskTicket(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket> CreateHelpDeskTicket(Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket helpDeskTicket = default(Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket))
        {
            var uri = new Uri(baseUri, $"HelpDeskTickets");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(helpDeskTicket), Encoding.UTF8, "application/json");

            OnCreateHelpDeskTicket(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>(response);
        }

        public async System.Threading.Tasks.Task ExportHelpDeskTicketDetailsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/helpdeskticketdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/helpdeskticketdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportHelpDeskTicketDetailsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/helpdeskticketdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/helpdeskticketdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetHelpDeskTicketDetails(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail>> GetHelpDeskTicketDetails(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"HelpDeskTicketDetails");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHelpDeskTicketDetails(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail>>(response);
        }
        partial void OnCreateHelpDeskTicketDetail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail> CreateHelpDeskTicketDetail(Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail helpDeskTicketDetail = default(Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail))
        {
            var uri = new Uri(baseUri, $"HelpDeskTicketDetails");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(helpDeskTicketDetail), Encoding.UTF8, "application/json");

            OnCreateHelpDeskTicketDetail(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail>(response);
        }

        public async System.Threading.Tasks.Task ExportLocalizationResourcesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/localizationresources/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/localizationresources/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportLocalizationResourcesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/localizationresources/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/localizationresources/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetLocalizationResources(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource>> GetLocalizationResources(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"LocalizationResources");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLocalizationResources(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource>>(response);
        }
        partial void OnCreateLocalizationResource(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource> CreateLocalizationResource(Cpdhelpdesk.Models.Authenticationconn.LocalizationResource localizationResource = default(Cpdhelpdesk.Models.Authenticationconn.LocalizationResource))
        {
            var uri = new Uri(baseUri, $"LocalizationResources");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(localizationResource), Encoding.UTF8, "application/json");

            OnCreateLocalizationResource(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource>(response);
        }

        public async System.Threading.Tasks.Task ExportLocalizationResourceTranslationsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/localizationresourcetranslations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/localizationresourcetranslations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportLocalizationResourceTranslationsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/localizationresourcetranslations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/localizationresourcetranslations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetLocalizationResourceTranslations(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation>> GetLocalizationResourceTranslations(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"LocalizationResourceTranslations");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLocalizationResourceTranslations(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation>>(response);
        }
        partial void OnCreateLocalizationResourceTranslation(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation> CreateLocalizationResourceTranslation(Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation localizationResourceTranslation = default(Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation))
        {
            var uri = new Uri(baseUri, $"LocalizationResourceTranslations");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(localizationResourceTranslation), Encoding.UTF8, "application/json");

            OnCreateLocalizationResourceTranslation(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation>(response);
        }

        public async System.Threading.Tasks.Task ExportLocationListsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/locationlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/locationlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportLocationListsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/locationlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/locationlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetLocationLists(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.LocationList>> GetLocationLists(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"LocationLists");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLocationLists(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.LocationList>>(response);
        }
        partial void OnCreateLocationList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.LocationList> CreateLocationList(Cpdhelpdesk.Models.Authenticationconn.LocationList locationList = default(Cpdhelpdesk.Models.Authenticationconn.LocationList))
        {
            var uri = new Uri(baseUri, $"LocationLists");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(locationList), Encoding.UTF8, "application/json");

            OnCreateLocationList(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.LocationList>(response);
        }

        public async System.Threading.Tasks.Task ExportMrtcontrollerNamesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/mrtcontrollernames/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/mrtcontrollernames/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMrtcontrollerNamesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/mrtcontrollernames/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/mrtcontrollernames/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMrtcontrollerNames(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName>> GetMrtcontrollerNames(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MrtcontrollerNames");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMrtcontrollerNames(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName>>(response);
        }
        partial void OnCreateMrtcontrollerName(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName> CreateMrtcontrollerName(Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName mrtcontrollerName = default(Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName))
        {
            var uri = new Uri(baseUri, $"MrtcontrollerNames");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mrtcontrollerName), Encoding.UTF8, "application/json");

            OnCreateMrtcontrollerName(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName>(response);
        }

        public async System.Threading.Tasks.Task ExportPersistedGrantsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/persistedgrants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/persistedgrants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportPersistedGrantsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/persistedgrants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/persistedgrants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetPersistedGrants(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.PersistedGrant>> GetPersistedGrants(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"PersistedGrants");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPersistedGrants(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.PersistedGrant>>(response);
        }
        partial void OnCreatePersistedGrant(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.PersistedGrant> CreatePersistedGrant(Cpdhelpdesk.Models.Authenticationconn.PersistedGrant persistedGrant = default(Cpdhelpdesk.Models.Authenticationconn.PersistedGrant))
        {
            var uri = new Uri(baseUri, $"PersistedGrants");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(persistedGrant), Encoding.UTF8, "application/json");

            OnCreatePersistedGrant(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.PersistedGrant>(response);
        }

        public async System.Threading.Tasks.Task ExportServiceCatglistsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/servicecatglists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/servicecatglists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportServiceCatglistsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/servicecatglists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/servicecatglists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetServiceCatglists(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist>> GetServiceCatglists(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ServiceCatglists");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetServiceCatglists(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist>>(response);
        }
        partial void OnCreateServiceCatglist(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist> CreateServiceCatglist(Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist serviceCatglist = default(Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist))
        {
            var uri = new Uri(baseUri, $"ServiceCatglists");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(serviceCatglist), Encoding.UTF8, "application/json");

            OnCreateServiceCatglist(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist>(response);
        }

        public async System.Threading.Tasks.Task ExportServicesListsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/serviceslists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/serviceslists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportServicesListsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/serviceslists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/serviceslists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetServicesLists(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.ServicesList>> GetServicesLists(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"ServicesLists");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetServicesLists(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.ServicesList>>(response);
        }
        partial void OnCreateServicesList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.ServicesList> CreateServicesList(Cpdhelpdesk.Models.Authenticationconn.ServicesList servicesList = default(Cpdhelpdesk.Models.Authenticationconn.ServicesList))
        {
            var uri = new Uri(baseUri, $"ServicesLists");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(servicesList), Encoding.UTF8, "application/json");

            OnCreateServicesList(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.ServicesList>(response);
        }

        public async System.Threading.Tasks.Task ExportSiteContentsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/sitecontents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/sitecontents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSiteContentsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/sitecontents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/sitecontents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetSiteContents(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.SiteContent>> GetSiteContents(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"SiteContents");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSiteContents(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.SiteContent>>(response);
        }
        partial void OnCreateSiteContent(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.SiteContent> CreateSiteContent(Cpdhelpdesk.Models.Authenticationconn.SiteContent siteContent = default(Cpdhelpdesk.Models.Authenticationconn.SiteContent))
        {
            var uri = new Uri(baseUri, $"SiteContents");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(siteContent), Encoding.UTF8, "application/json");

            OnCreateSiteContent(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.SiteContent>(response);
        }

        public async System.Threading.Tasks.Task ExportSmsListsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/smslists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/smslists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSmsListsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/smslists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/smslists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetSmsLists(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.SmsList>> GetSmsLists(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"SmsLists");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSmsLists(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.SmsList>>(response);
        }
        partial void OnCreateSmsList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.SmsList> CreateSmsList(Cpdhelpdesk.Models.Authenticationconn.SmsList smsList = default(Cpdhelpdesk.Models.Authenticationconn.SmsList))
        {
            var uri = new Uri(baseUri, $"SmsLists");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(smsList), Encoding.UTF8, "application/json");

            OnCreateSmsList(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.SmsList>(response);
        }

        public async System.Threading.Tasks.Task ExportSmsbrandsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/smsbrands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/smsbrands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSmsbrandsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/smsbrands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/smsbrands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetSmsbrands(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.Smsbrand>> GetSmsbrands(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Smsbrands");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSmsbrands(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.Smsbrand>>(response);
        }
        partial void OnCreateSmsbrand(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.Smsbrand> CreateSmsbrand(Cpdhelpdesk.Models.Authenticationconn.Smsbrand smsbrand = default(Cpdhelpdesk.Models.Authenticationconn.Smsbrand))
        {
            var uri = new Uri(baseUri, $"Smsbrands");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(smsbrand), Encoding.UTF8, "application/json");

            OnCreateSmsbrand(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.Smsbrand>(response);
        }

        public async System.Threading.Tasks.Task ExportSmscatidsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/smscatids/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/smscatids/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSmscatidsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/smscatids/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/smscatids/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetSmscatids(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.Smscatid>> GetSmscatids(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Smscatids");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSmscatids(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.Smscatid>>(response);
        }
        partial void OnCreateSmscatid(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.Smscatid> CreateSmscatid(Cpdhelpdesk.Models.Authenticationconn.Smscatid smscatid = default(Cpdhelpdesk.Models.Authenticationconn.Smscatid))
        {
            var uri = new Uri(baseUri, $"Smscatids");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(smscatid), Encoding.UTF8, "application/json");

            OnCreateSmscatid(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.Smscatid>(response);
        }

        public async System.Threading.Tasks.Task ExportSmsqueueListsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/smsqueuelists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/smsqueuelists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSmsqueueListsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/smsqueuelists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/smsqueuelists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetSmsqueueLists(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>> GetSmsqueueLists(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"SmsqueueLists");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSmsqueueLists(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>>(response);
        }
        partial void OnCreateSmsqueueList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList> CreateSmsqueueList(Cpdhelpdesk.Models.Authenticationconn.SmsqueueList smsqueueList = default(Cpdhelpdesk.Models.Authenticationconn.SmsqueueList))
        {
            var uri = new Uri(baseUri, $"SmsqueueLists");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(smsqueueList), Encoding.UTF8, "application/json");

            OnCreateSmsqueueList(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>(response);
        }

        public async System.Threading.Tasks.Task ExportSmsqueueListdsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/smsqueuelistds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/smsqueuelistds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSmsqueueListdsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/smsqueuelistds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/smsqueuelistds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetSmsqueueListds(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>> GetSmsqueueListds(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"SmsqueueListds");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSmsqueueListds(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>>(response);
        }
        partial void OnCreateSmsqueueListd(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd> CreateSmsqueueListd(Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd smsqueueListd = default(Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd))
        {
            var uri = new Uri(baseUri, $"SmsqueueListds");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(smsqueueListd), Encoding.UTF8, "application/json");

            OnCreateSmsqueueListd(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>(response);
        }

        public async System.Threading.Tasks.Task ExportSoftwareModulescatlistsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/softwaremodulescatlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/softwaremodulescatlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSoftwareModulescatlistsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/softwaremodulescatlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/softwaremodulescatlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetSoftwareModulescatlists(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist>> GetSoftwareModulescatlists(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"SoftwareModulescatlists");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSoftwareModulescatlists(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist>>(response);
        }
        partial void OnCreateSoftwareModulescatlist(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist> CreateSoftwareModulescatlist(Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist softwareModulescatlist = default(Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist))
        {
            var uri = new Uri(baseUri, $"SoftwareModulescatlists");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(softwareModulescatlist), Encoding.UTF8, "application/json");

            OnCreateSoftwareModulescatlist(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist>(response);
        }

        public async System.Threading.Tasks.Task ExportTblPagesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/tblpages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/tblpages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTblPagesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/tblpages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/tblpages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetTblPages(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.TblPage>> GetTblPages(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TblPages");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblPages(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.TblPage>>(response);
        }
        partial void OnCreateTblPage(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.TblPage> CreateTblPage(Cpdhelpdesk.Models.Authenticationconn.TblPage tblPage = default(Cpdhelpdesk.Models.Authenticationconn.TblPage))
        {
            var uri = new Uri(baseUri, $"TblPages");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblPage), Encoding.UTF8, "application/json");

            OnCreateTblPage(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.TblPage>(response);
        }

        public async System.Threading.Tasks.Task ExportTelphonUsersListsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/telphonuserslists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/telphonuserslists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTelphonUsersListsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/telphonuserslists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/telphonuserslists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetTelphonUsersLists(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList>> GetTelphonUsersLists(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TelphonUsersLists");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTelphonUsersLists(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList>>(response);
        }
        partial void OnCreateTelphonUsersList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList> CreateTelphonUsersList(Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList telphonUsersList = default(Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList))
        {
            var uri = new Uri(baseUri, $"TelphonUsersLists");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(telphonUsersList), Encoding.UTF8, "application/json");

            OnCreateTelphonUsersList(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList>(response);
        }

        public async System.Threading.Tasks.Task ExportTicketRequesterUsersListsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/ticketrequesteruserslists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/ticketrequesteruserslists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTicketRequesterUsersListsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/ticketrequesteruserslists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/ticketrequesteruserslists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetTicketRequesterUsersLists(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList>> GetTicketRequesterUsersLists(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"TicketRequesterUsersLists");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTicketRequesterUsersLists(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList>>(response);
        }
        partial void OnCreateTicketRequesterUsersList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList> CreateTicketRequesterUsersList(Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList ticketRequesterUsersList = default(Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList))
        {
            var uri = new Uri(baseUri, $"TicketRequesterUsersLists");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ticketRequesterUsersList), Encoding.UTF8, "application/json");

            OnCreateTicketRequesterUsersList(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList>(response);
        }

        public async System.Threading.Tasks.Task ExportUserAuditsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/useraudits/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/useraudits/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportUserAuditsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/authenticationconn/useraudits/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/authenticationconn/useraudits/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetUserAudits(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.UserAudit>> GetUserAudits(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"UserAudits");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetUserAudits(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Cpdhelpdesk.Models.Authenticationconn.UserAudit>>(response);
        }
        partial void OnCreateUserAudit(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.UserAudit> CreateUserAudit(Cpdhelpdesk.Models.Authenticationconn.UserAudit userAudit = default(Cpdhelpdesk.Models.Authenticationconn.UserAudit))
        {
            var uri = new Uri(baseUri, $"UserAudits");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(userAudit), Encoding.UTF8, "application/json");

            OnCreateUserAudit(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.UserAudit>(response);
        }
        partial void OnDeleteCustomerswhatsapp(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteCustomerswhatsapp(Int64? cstmNo = default(Int64?))
        {
            var uri = new Uri(baseUri, $"Customerswhatsapps({cstmNo})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteCustomerswhatsapp(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetCustomerswhatsappByCstmNo(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp> GetCustomerswhatsappByCstmNo(string expand = default(string), Int64? cstmNo = default(Int64?))
        {
            var uri = new Uri(baseUri, $"Customerswhatsapps({cstmNo})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCustomerswhatsappByCstmNo(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp>(response);
        }
        partial void OnUpdateCustomerswhatsapp(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateCustomerswhatsapp(Int64? cstmNo = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp customerswhatsapp = default(Cpdhelpdesk.Models.Authenticationconn.Customerswhatsapp))
        {
            var uri = new Uri(baseUri, $"Customerswhatsapps({cstmNo})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", customerswhatsapp.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(customerswhatsapp), Encoding.UTF8, "application/json");

            OnUpdateCustomerswhatsapp(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteDeviceCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDeviceCode(string userCode = default(string))
        {
            var uri = new Uri(baseUri, $"DeviceCodes('{HttpUtility.UrlEncode(userCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDeviceCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDeviceCodeByUserCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.DeviceCode> GetDeviceCodeByUserCode(string expand = default(string), string userCode = default(string))
        {
            var uri = new Uri(baseUri, $"DeviceCodes('{HttpUtility.UrlEncode(userCode.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeviceCodeByUserCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.DeviceCode>(response);
        }
        partial void OnUpdateDeviceCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDeviceCode(string userCode = default(string), Cpdhelpdesk.Models.Authenticationconn.DeviceCode deviceCode = default(Cpdhelpdesk.Models.Authenticationconn.DeviceCode))
        {
            var uri = new Uri(baseUri, $"DeviceCodes('{HttpUtility.UrlEncode(userCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", deviceCode.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(deviceCode), Encoding.UTF8, "application/json");

            OnUpdateDeviceCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteEmailsWhatsappQeue(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteEmailsWhatsappQeue(Int64? emailqeueId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"EmailsWhatsappQeues({emailqeueId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEmailsWhatsappQeue(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetEmailsWhatsappQeueByEmailqeueId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue> GetEmailsWhatsappQeueByEmailqeueId(string expand = default(string), Int64? emailqeueId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"EmailsWhatsappQeues({emailqeueId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmailsWhatsappQeueByEmailqeueId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue>(response);
        }
        partial void OnUpdateEmailsWhatsappQeue(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateEmailsWhatsappQeue(Int64? emailqeueId = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue emailsWhatsappQeue = default(Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeue))
        {
            var uri = new Uri(baseUri, $"EmailsWhatsappQeues({emailqeueId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", emailsWhatsappQeue.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(emailsWhatsappQeue), Encoding.UTF8, "application/json");

            OnUpdateEmailsWhatsappQeue(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteEmailsWhatsappQeueemail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteEmailsWhatsappQeueemail(Int64? emailqeueId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"EmailsWhatsappQeueemails({emailqeueId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEmailsWhatsappQeueemail(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetEmailsWhatsappQeueemailByEmailqeueId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail> GetEmailsWhatsappQeueemailByEmailqeueId(string expand = default(string), Int64? emailqeueId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"EmailsWhatsappQeueemails({emailqeueId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmailsWhatsappQeueemailByEmailqeueId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail>(response);
        }
        partial void OnUpdateEmailsWhatsappQeueemail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateEmailsWhatsappQeueemail(Int64? emailqeueId = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail emailsWhatsappQeueemail = default(Cpdhelpdesk.Models.Authenticationconn.EmailsWhatsappQeueemail))
        {
            var uri = new Uri(baseUri, $"EmailsWhatsappQeueemails({emailqeueId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", emailsWhatsappQeueemail.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(emailsWhatsappQeueemail), Encoding.UTF8, "application/json");

            OnUpdateEmailsWhatsappQeueemail(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteEmpDepartment(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteEmpDepartment(Int64? empDepartmentId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"EmpDepartments({empDepartmentId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEmpDepartment(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetEmpDepartmentByEmpDepartmentId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment> GetEmpDepartmentByEmpDepartmentId(string expand = default(string), Int64? empDepartmentId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"EmpDepartments({empDepartmentId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmpDepartmentByEmpDepartmentId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment>(response);
        }
        partial void OnUpdateEmpDepartment(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateEmpDepartment(Int64? empDepartmentId = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.EmpDepartment empDepartment = default(Cpdhelpdesk.Models.Authenticationconn.EmpDepartment))
        {
            var uri = new Uri(baseUri, $"EmpDepartments({empDepartmentId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", empDepartment.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(empDepartment), Encoding.UTF8, "application/json");

            OnUpdateEmpDepartment(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteEmpJoblist(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteEmpJoblist(Int64? empjoblistId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"EmpJoblists({empjoblistId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteEmpJoblist(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetEmpJoblistByEmpjoblistId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist> GetEmpJoblistByEmpjoblistId(string expand = default(string), Int64? empjoblistId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"EmpJoblists({empjoblistId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetEmpJoblistByEmpjoblistId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist>(response);
        }
        partial void OnUpdateEmpJoblist(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateEmpJoblist(Int64? empjoblistId = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.EmpJoblist empJoblist = default(Cpdhelpdesk.Models.Authenticationconn.EmpJoblist))
        {
            var uri = new Uri(baseUri, $"EmpJoblists({empjoblistId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", empJoblist.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(empJoblist), Encoding.UTF8, "application/json");

            OnUpdateEmpJoblist(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteHelpDeskStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteHelpDeskStatus(string ticketStatus = default(string))
        {
            var uri = new Uri(baseUri, $"HelpDeskStatuses('{HttpUtility.UrlEncode(ticketStatus.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteHelpDeskStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetHelpDeskStatusByTicketStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus> GetHelpDeskStatusByTicketStatus(string expand = default(string), string ticketStatus = default(string))
        {
            var uri = new Uri(baseUri, $"HelpDeskStatuses('{HttpUtility.UrlEncode(ticketStatus.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHelpDeskStatusByTicketStatus(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus>(response);
        }
        partial void OnUpdateHelpDeskStatus(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateHelpDeskStatus(string ticketStatus = default(string), Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus helpDeskStatus = default(Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus))
        {
            var uri = new Uri(baseUri, $"HelpDeskStatuses('{HttpUtility.UrlEncode(ticketStatus.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", helpDeskStatus.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(helpDeskStatus), Encoding.UTF8, "application/json");

            OnUpdateHelpDeskStatus(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteHelpDeskTicket(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteHelpDeskTicket(Int64? id = default(Int64?))
        {
            var uri = new Uri(baseUri, $"HelpDeskTickets({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteHelpDeskTicket(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetHelpDeskTicketById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket> GetHelpDeskTicketById(string expand = default(string), Int64? id = default(Int64?))
        {
            var uri = new Uri(baseUri, $"HelpDeskTickets({id})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHelpDeskTicketById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket>(response);
        }
        partial void OnUpdateHelpDeskTicket(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateHelpDeskTicket(Int64? id = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket helpDeskTicket = default(Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket))
        {
            var uri = new Uri(baseUri, $"HelpDeskTickets({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", helpDeskTicket.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(helpDeskTicket), Encoding.UTF8, "application/json");

            OnUpdateHelpDeskTicket(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteHelpDeskTicketDetail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteHelpDeskTicketDetail(Int64? id = default(Int64?))
        {
            var uri = new Uri(baseUri, $"HelpDeskTicketDetails({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteHelpDeskTicketDetail(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetHelpDeskTicketDetailById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail> GetHelpDeskTicketDetailById(string expand = default(string), Int64? id = default(Int64?))
        {
            var uri = new Uri(baseUri, $"HelpDeskTicketDetails({id})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetHelpDeskTicketDetailById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail>(response);
        }
        partial void OnUpdateHelpDeskTicketDetail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateHelpDeskTicketDetail(Int64? id = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail helpDeskTicketDetail = default(Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail))
        {
            var uri = new Uri(baseUri, $"HelpDeskTicketDetails({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", helpDeskTicketDetail.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(helpDeskTicketDetail), Encoding.UTF8, "application/json");

            OnUpdateHelpDeskTicketDetail(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteLocalizationResource(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteLocalizationResource(int? id = default(int?))
        {
            var uri = new Uri(baseUri, $"LocalizationResources({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteLocalizationResource(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetLocalizationResourceById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource> GetLocalizationResourceById(string expand = default(string), int? id = default(int?))
        {
            var uri = new Uri(baseUri, $"LocalizationResources({id})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLocalizationResourceById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource>(response);
        }
        partial void OnUpdateLocalizationResource(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateLocalizationResource(int? id = default(int?), Cpdhelpdesk.Models.Authenticationconn.LocalizationResource localizationResource = default(Cpdhelpdesk.Models.Authenticationconn.LocalizationResource))
        {
            var uri = new Uri(baseUri, $"LocalizationResources({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", localizationResource.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(localizationResource), Encoding.UTF8, "application/json");

            OnUpdateLocalizationResource(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteLocalizationResourceTranslation(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteLocalizationResourceTranslation(int? id = default(int?))
        {
            var uri = new Uri(baseUri, $"LocalizationResourceTranslations({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteLocalizationResourceTranslation(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetLocalizationResourceTranslationById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation> GetLocalizationResourceTranslationById(string expand = default(string), int? id = default(int?))
        {
            var uri = new Uri(baseUri, $"LocalizationResourceTranslations({id})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLocalizationResourceTranslationById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation>(response);
        }
        partial void OnUpdateLocalizationResourceTranslation(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateLocalizationResourceTranslation(int? id = default(int?), Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation localizationResourceTranslation = default(Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation))
        {
            var uri = new Uri(baseUri, $"LocalizationResourceTranslations({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", localizationResourceTranslation.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(localizationResourceTranslation), Encoding.UTF8, "application/json");

            OnUpdateLocalizationResourceTranslation(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteLocationList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteLocationList(Int64? locationId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"LocationLists({locationId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteLocationList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetLocationListBylocationId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.LocationList> GetLocationListBylocationId(string expand = default(string), Int64? locationId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"LocationLists({locationId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLocationListBylocationId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.LocationList>(response);
        }
        partial void OnUpdateLocationList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateLocationList(Int64? locationId = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.LocationList locationList = default(Cpdhelpdesk.Models.Authenticationconn.LocationList))
        {
            var uri = new Uri(baseUri, $"LocationLists({locationId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", locationList.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(locationList), Encoding.UTF8, "application/json");

            OnUpdateLocationList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMrtcontrollerName(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMrtcontrollerName(Int64? controllerNameid = default(Int64?))
        {
            var uri = new Uri(baseUri, $"MrtcontrollerNames({controllerNameid})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMrtcontrollerName(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMrtcontrollerNameBycontrollerNameid(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName> GetMrtcontrollerNameBycontrollerNameid(string expand = default(string), Int64? controllerNameid = default(Int64?))
        {
            var uri = new Uri(baseUri, $"MrtcontrollerNames({controllerNameid})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMrtcontrollerNameBycontrollerNameid(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName>(response);
        }
        partial void OnUpdateMrtcontrollerName(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMrtcontrollerName(Int64? controllerNameid = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName mrtcontrollerName = default(Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName))
        {
            var uri = new Uri(baseUri, $"MrtcontrollerNames({controllerNameid})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", mrtcontrollerName.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(mrtcontrollerName), Encoding.UTF8, "application/json");

            OnUpdateMrtcontrollerName(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeletePersistedGrant(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeletePersistedGrant(string key = default(string))
        {
            var uri = new Uri(baseUri, $"PersistedGrants('{HttpUtility.UrlEncode(key.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletePersistedGrant(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetPersistedGrantByKey(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.PersistedGrant> GetPersistedGrantByKey(string expand = default(string), string key = default(string))
        {
            var uri = new Uri(baseUri, $"PersistedGrants('{HttpUtility.UrlEncode(key.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPersistedGrantByKey(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.PersistedGrant>(response);
        }
        partial void OnUpdatePersistedGrant(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdatePersistedGrant(string key = default(string), Cpdhelpdesk.Models.Authenticationconn.PersistedGrant persistedGrant = default(Cpdhelpdesk.Models.Authenticationconn.PersistedGrant))
        {
            var uri = new Uri(baseUri, $"PersistedGrants('{HttpUtility.UrlEncode(key.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", persistedGrant.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(persistedGrant), Encoding.UTF8, "application/json");

            OnUpdatePersistedGrant(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteServiceCatglist(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteServiceCatglist(Int64? serviceCatgId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"ServiceCatglists({serviceCatgId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteServiceCatglist(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetServiceCatglistByServiceCatgId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist> GetServiceCatglistByServiceCatgId(string expand = default(string), Int64? serviceCatgId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"ServiceCatglists({serviceCatgId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetServiceCatglistByServiceCatgId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist>(response);
        }
        partial void OnUpdateServiceCatglist(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateServiceCatglist(Int64? serviceCatgId = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist serviceCatglist = default(Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist))
        {
            var uri = new Uri(baseUri, $"ServiceCatglists({serviceCatgId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", serviceCatglist.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(serviceCatglist), Encoding.UTF8, "application/json");

            OnUpdateServiceCatglist(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteServicesList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteServicesList(Int64? serviceId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"ServicesLists({serviceId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteServicesList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetServicesListByServiceId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.ServicesList> GetServicesListByServiceId(string expand = default(string), Int64? serviceId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"ServicesLists({serviceId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetServicesListByServiceId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.ServicesList>(response);
        }
        partial void OnUpdateServicesList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateServicesList(Int64? serviceId = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.ServicesList servicesList = default(Cpdhelpdesk.Models.Authenticationconn.ServicesList))
        {
            var uri = new Uri(baseUri, $"ServicesLists({serviceId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", servicesList.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(servicesList), Encoding.UTF8, "application/json");

            OnUpdateServicesList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteSiteContent(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSiteContent(Guid? siteContentId = default(Guid?))
        {
            var uri = new Uri(baseUri, $"SiteContents({siteContentId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSiteContent(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetSiteContentBySiteContentId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.SiteContent> GetSiteContentBySiteContentId(string expand = default(string), Guid? siteContentId = default(Guid?))
        {
            var uri = new Uri(baseUri, $"SiteContents({siteContentId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSiteContentBySiteContentId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.SiteContent>(response);
        }
        partial void OnUpdateSiteContent(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateSiteContent(Guid? siteContentId = default(Guid?), Cpdhelpdesk.Models.Authenticationconn.SiteContent siteContent = default(Cpdhelpdesk.Models.Authenticationconn.SiteContent))
        {
            var uri = new Uri(baseUri, $"SiteContents({siteContentId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", siteContent.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(siteContent), Encoding.UTF8, "application/json");

            OnUpdateSiteContent(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteSmsList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSmsList(Int64? smSidauto = default(Int64?))
        {
            var uri = new Uri(baseUri, $"SmsLists({smSidauto})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSmsList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetSmsListBySmSidauto(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.SmsList> GetSmsListBySmSidauto(string expand = default(string), Int64? smSidauto = default(Int64?))
        {
            var uri = new Uri(baseUri, $"SmsLists({smSidauto})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSmsListBySmSidauto(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.SmsList>(response);
        }
        partial void OnUpdateSmsList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateSmsList(Int64? smSidauto = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.SmsList smsList = default(Cpdhelpdesk.Models.Authenticationconn.SmsList))
        {
            var uri = new Uri(baseUri, $"SmsLists({smSidauto})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", smsList.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(smsList), Encoding.UTF8, "application/json");

            OnUpdateSmsList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteSmsbrand(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSmsbrand(Int64? smsbrand1 = default(Int64?))
        {
            var uri = new Uri(baseUri, $"Smsbrands({smsbrand1})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSmsbrand(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetSmsbrandBysmsbrand1(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.Smsbrand> GetSmsbrandBysmsbrand1(string expand = default(string), Int64? smsbrand1 = default(Int64?))
        {
            var uri = new Uri(baseUri, $"Smsbrands({smsbrand1})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSmsbrandBysmsbrand1(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.Smsbrand>(response);
        }
        partial void OnUpdateSmsbrand(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateSmsbrand(Int64? smsbrand1 = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.Smsbrand smsbrand = default(Cpdhelpdesk.Models.Authenticationconn.Smsbrand))
        {
            var uri = new Uri(baseUri, $"Smsbrands({smsbrand1})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", smsbrand.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(smsbrand), Encoding.UTF8, "application/json");

            OnUpdateSmsbrand(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteSmscatid(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSmscatid(Int64? smscatid1 = default(Int64?))
        {
            var uri = new Uri(baseUri, $"Smscatids({smscatid1})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSmscatid(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetSmscatidBysmscatid1(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.Smscatid> GetSmscatidBysmscatid1(string expand = default(string), Int64? smscatid1 = default(Int64?))
        {
            var uri = new Uri(baseUri, $"Smscatids({smscatid1})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSmscatidBysmscatid1(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.Smscatid>(response);
        }
        partial void OnUpdateSmscatid(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateSmscatid(Int64? smscatid1 = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.Smscatid smscatid = default(Cpdhelpdesk.Models.Authenticationconn.Smscatid))
        {
            var uri = new Uri(baseUri, $"Smscatids({smscatid1})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", smscatid.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(smscatid), Encoding.UTF8, "application/json");

            OnUpdateSmscatid(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteSmsqueueList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSmsqueueList(Int64? smsqueueid = default(Int64?))
        {
            var uri = new Uri(baseUri, $"SmsqueueLists({smsqueueid})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSmsqueueList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetSmsqueueListBySmsqueueid(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList> GetSmsqueueListBySmsqueueid(string expand = default(string), Int64? smsqueueid = default(Int64?))
        {
            var uri = new Uri(baseUri, $"SmsqueueLists({smsqueueid})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSmsqueueListBySmsqueueid(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.SmsqueueList>(response);
        }
        partial void OnUpdateSmsqueueList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateSmsqueueList(Int64? smsqueueid = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.SmsqueueList smsqueueList = default(Cpdhelpdesk.Models.Authenticationconn.SmsqueueList))
        {
            var uri = new Uri(baseUri, $"SmsqueueLists({smsqueueid})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", smsqueueList.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(smsqueueList), Encoding.UTF8, "application/json");

            OnUpdateSmsqueueList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteSmsqueueListd(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSmsqueueListd(Int64? smsqueueid = default(Int64?))
        {
            var uri = new Uri(baseUri, $"SmsqueueListds({smsqueueid})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSmsqueueListd(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetSmsqueueListdBySmsqueueid(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd> GetSmsqueueListdBySmsqueueid(string expand = default(string), Int64? smsqueueid = default(Int64?))
        {
            var uri = new Uri(baseUri, $"SmsqueueListds({smsqueueid})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSmsqueueListdBySmsqueueid(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd>(response);
        }
        partial void OnUpdateSmsqueueListd(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateSmsqueueListd(Int64? smsqueueid = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd smsqueueListd = default(Cpdhelpdesk.Models.Authenticationconn.SmsqueueListd))
        {
            var uri = new Uri(baseUri, $"SmsqueueListds({smsqueueid})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", smsqueueListd.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(smsqueueListd), Encoding.UTF8, "application/json");

            OnUpdateSmsqueueListd(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteSoftwareModulescatlist(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSoftwareModulescatlist(Int64? sprModulecatid = default(Int64?))
        {
            var uri = new Uri(baseUri, $"SoftwareModulescatlists({sprModulecatid})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSoftwareModulescatlist(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetSoftwareModulescatlistBysprModulecatid(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist> GetSoftwareModulescatlistBysprModulecatid(string expand = default(string), Int64? sprModulecatid = default(Int64?))
        {
            var uri = new Uri(baseUri, $"SoftwareModulescatlists({sprModulecatid})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSoftwareModulescatlistBysprModulecatid(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist>(response);
        }
        partial void OnUpdateSoftwareModulescatlist(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateSoftwareModulescatlist(Int64? sprModulecatid = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist softwareModulescatlist = default(Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist))
        {
            var uri = new Uri(baseUri, $"SoftwareModulescatlists({sprModulecatid})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", softwareModulescatlist.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(softwareModulescatlist), Encoding.UTF8, "application/json");

            OnUpdateSoftwareModulescatlist(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteTblPage(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteTblPage(int? id = default(int?))
        {
            var uri = new Uri(baseUri, $"TblPages({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTblPage(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetTblPageByid(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.TblPage> GetTblPageByid(string expand = default(string), int? id = default(int?))
        {
            var uri = new Uri(baseUri, $"TblPages({id})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTblPageByid(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.TblPage>(response);
        }
        partial void OnUpdateTblPage(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateTblPage(int? id = default(int?), Cpdhelpdesk.Models.Authenticationconn.TblPage tblPage = default(Cpdhelpdesk.Models.Authenticationconn.TblPage))
        {
            var uri = new Uri(baseUri, $"TblPages({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", tblPage.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(tblPage), Encoding.UTF8, "application/json");

            OnUpdateTblPage(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteTelphonUsersList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteTelphonUsersList(Int64? telphonUsersListId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"TelphonUsersLists({telphonUsersListId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTelphonUsersList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetTelphonUsersListByTelphonUsersListId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList> GetTelphonUsersListByTelphonUsersListId(string expand = default(string), Int64? telphonUsersListId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"TelphonUsersLists({telphonUsersListId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTelphonUsersListByTelphonUsersListId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList>(response);
        }
        partial void OnUpdateTelphonUsersList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateTelphonUsersList(Int64? telphonUsersListId = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList telphonUsersList = default(Cpdhelpdesk.Models.Authenticationconn.TelphonUsersList))
        {
            var uri = new Uri(baseUri, $"TelphonUsersLists({telphonUsersListId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", telphonUsersList.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(telphonUsersList), Encoding.UTF8, "application/json");

            OnUpdateTelphonUsersList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteTicketRequesterUsersList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteTicketRequesterUsersList(string ticketRequesterUser = default(string))
        {
            var uri = new Uri(baseUri, $"TicketRequesterUsersLists('{HttpUtility.UrlEncode(ticketRequesterUser.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTicketRequesterUsersList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetTicketRequesterUsersListByTicketRequesterUser(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList> GetTicketRequesterUsersListByTicketRequesterUser(string expand = default(string), string ticketRequesterUser = default(string))
        {
            var uri = new Uri(baseUri, $"TicketRequesterUsersLists('{HttpUtility.UrlEncode(ticketRequesterUser.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTicketRequesterUsersListByTicketRequesterUser(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList>(response);
        }
        partial void OnUpdateTicketRequesterUsersList(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateTicketRequesterUsersList(string ticketRequesterUser = default(string), Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList ticketRequesterUsersList = default(Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList))
        {
            var uri = new Uri(baseUri, $"TicketRequesterUsersLists('{HttpUtility.UrlEncode(ticketRequesterUser.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", ticketRequesterUsersList.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(ticketRequesterUsersList), Encoding.UTF8, "application/json");

            OnUpdateTicketRequesterUsersList(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteUserAudit(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteUserAudit(Int64? userAuditId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"UserAudits({userAuditId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteUserAudit(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetUserAuditByUserAuditId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Cpdhelpdesk.Models.Authenticationconn.UserAudit> GetUserAuditByUserAuditId(string expand = default(string), Int64? userAuditId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"UserAudits({userAuditId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetUserAuditByUserAuditId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Cpdhelpdesk.Models.Authenticationconn.UserAudit>(response);
        }
        partial void OnUpdateUserAudit(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateUserAudit(Int64? userAuditId = default(Int64?), Cpdhelpdesk.Models.Authenticationconn.UserAudit userAudit = default(Cpdhelpdesk.Models.Authenticationconn.UserAudit))
        {
            var uri = new Uri(baseUri, $"UserAudits({userAuditId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", userAudit.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(userAudit), Encoding.UTF8, "application/json");

            OnUpdateUserAudit(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
