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
    public partial class HelpDeskStatusesComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus> grid0;

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

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus> _getHelpDeskStatusesResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus> getHelpDeskStatusesResult
        {
            get
            {
                return _getHelpDeskStatusesResult;
            }
            set
            {
                if (!object.Equals(_getHelpDeskStatusesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getHelpDeskStatusesResult", NewValue = value, OldValue = _getHelpDeskStatusesResult };
                    _getHelpDeskStatusesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getHelpDeskStatusesCount;
        protected int getHelpDeskStatusesCount
        {
            get
            {
                return _getHelpDeskStatusesCount;
            }
            set
            {
                if (!object.Equals(_getHelpDeskStatusesCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getHelpDeskStatusesCount", NewValue = value, OldValue = _getHelpDeskStatusesCount };
                    _getHelpDeskStatusesCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddHelpDeskStatus>("Add Help Desk Status", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Authenticationconn.ExportHelpDeskStatusesToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TicketStatus,TicketStatusDesc" }, $"Help Desk Statuses");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Authenticationconn.ExportHelpDeskStatusesToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TicketStatus,TicketStatusDesc" }, $"Help Desk Statuses");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetHelpDeskStatusesResult = await Authenticationconn.GetHelpDeskStatuses(filter:$@"(contains(TicketStatus,""{search}"") or contains(TicketStatusDesc,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getHelpDeskStatusesResult = authenticationconnGetHelpDeskStatusesResult.Value.AsODataEnumerable();

                getHelpDeskStatusesCount = authenticationconnGetHelpDeskStatusesResult.Count;
            }
            catch (System.Exception authenticationconnGetHelpDeskStatusesException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load HelpDeskStatuses" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Cpdhelpdesk.Models.Authenticationconn.HelpDeskStatus> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditHelpDeskStatus>("Edit Help Desk Status", new Dictionary<string, object>() { {"TicketStatus", args.Data.TicketStatus} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteHelpDeskStatusResult = await Authenticationconn.DeleteHelpDeskStatus(ticketStatus:$"{data.TicketStatus}");
                    if (authenticationconnDeleteHelpDeskStatusResult != null && authenticationconnDeleteHelpDeskStatusResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (authenticationconnDeleteHelpDeskStatusResult != null && authenticationconnDeleteHelpDeskStatusResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete HelpDeskStatus" });
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteHelpDeskStatusException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete HelpDeskStatus" });
            }
        }
    }
}
