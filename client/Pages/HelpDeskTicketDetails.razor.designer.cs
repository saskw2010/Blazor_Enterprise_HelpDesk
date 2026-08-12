using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Cpdhelpdesk.Models.Authenticationconn;
using Cpdhelpdesk.Models;
using Cpdhelpdesk.Client.Pages;

namespace Cpdhelpdesk.Pages
{
    public partial class HelpDeskTicketDetailsComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected AuthenticationconnService Authenticationconn { get; set; }
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail> grid0;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail> _getHelpDeskTicketDetailsResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail> getHelpDeskTicketDetailsResult
        {
            get
            {
                return _getHelpDeskTicketDetailsResult;
            }
            set
            {
                if (!object.Equals(_getHelpDeskTicketDetailsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getHelpDeskTicketDetailsResult", NewValue = value, OldValue = _getHelpDeskTicketDetailsResult };
                    _getHelpDeskTicketDetailsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getHelpDeskTicketDetailsCount;
        protected int getHelpDeskTicketDetailsCount
        {
            get
            {
                return _getHelpDeskTicketDetailsCount;
            }
            set
            {
                if (!object.Equals(_getHelpDeskTicketDetailsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getHelpDeskTicketDetailsCount", NewValue = value, OldValue = _getHelpDeskTicketDetailsCount };
                    _getHelpDeskTicketDetailsCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddHelpDeskTicketDetail>("Add Help Desk Ticket Detail", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Authenticationconn.ExportHelpDeskTicketDetailsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "HelpDeskTicket", Select = "Id,HelpDeskTicket.TicketGUID as HelpDeskTicketTicketGUID,TicketDetailDate,TicketDescription,TicketResponseUser" }, $"Help Desk Ticket Details");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Authenticationconn.ExportHelpDeskTicketDetailsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "HelpDeskTicket", Select = "Id,HelpDeskTicket.TicketGUID as HelpDeskTicketTicketGUID,TicketDetailDate,TicketDescription,TicketResponseUser" }, $"Help Desk Ticket Details");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetHelpDeskTicketDetailsResult = await Authenticationconn.GetHelpDeskTicketDetails(filter:$@"(contains(TicketDescription,""{search}"") or contains(TicketResponseUser,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", expand:$"HelpDeskTicket", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getHelpDeskTicketDetailsResult = authenticationconnGetHelpDeskTicketDetailsResult.Value.AsODataEnumerable();

                getHelpDeskTicketDetailsCount = authenticationconnGetHelpDeskTicketDetailsResult.Count;
            }
            catch (System.Exception authenticationconnGetHelpDeskTicketDetailsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load HelpDeskTicketDetails" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicketDetail> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditHelpDeskTicketDetail>("Edit Help Desk Ticket Detail", new Dictionary<string, object>() { {"Id", args.Data.Id} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteHelpDeskTicketDetailResult = await Authenticationconn.DeleteHelpDeskTicketDetail(id:data.Id);
                    if (authenticationconnDeleteHelpDeskTicketDetailResult != null && authenticationconnDeleteHelpDeskTicketDetailResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (authenticationconnDeleteHelpDeskTicketDetailResult != null && authenticationconnDeleteHelpDeskTicketDetailResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete HelpDeskTicketDetail" });
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteHelpDeskTicketDetailException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete HelpDeskTicketDetail" });
            }
        }
    }
}
