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
    public partial class TicketRequesterUsersListsComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList> grid0;

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

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList> _getTicketRequesterUsersListsResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList> getTicketRequesterUsersListsResult
        {
            get
            {
                return _getTicketRequesterUsersListsResult;
            }
            set
            {
                if (!object.Equals(_getTicketRequesterUsersListsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTicketRequesterUsersListsResult", NewValue = value, OldValue = _getTicketRequesterUsersListsResult };
                    _getTicketRequesterUsersListsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getTicketRequesterUsersListsCount;
        protected int getTicketRequesterUsersListsCount
        {
            get
            {
                return _getTicketRequesterUsersListsCount;
            }
            set
            {
                if (!object.Equals(_getTicketRequesterUsersListsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTicketRequesterUsersListsCount", NewValue = value, OldValue = _getTicketRequesterUsersListsCount };
                    _getTicketRequesterUsersListsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddTicketRequesterUsersList>("Add Ticket Requester Users List", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Authenticationconn.ExportTicketRequesterUsersListsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TicketRequesterUser,TicketRequesterEmail" }, $"Ticket Requester Users Lists");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Authenticationconn.ExportTicketRequesterUsersListsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "TicketRequesterUser,TicketRequesterEmail" }, $"Ticket Requester Users Lists");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetTicketRequesterUsersListsResult = await Authenticationconn.GetTicketRequesterUsersLists(filter:$@"(contains(TicketRequesterUser,""{search}"") or contains(TicketRequesterEmail,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getTicketRequesterUsersListsResult = authenticationconnGetTicketRequesterUsersListsResult.Value.AsODataEnumerable();

                getTicketRequesterUsersListsCount = authenticationconnGetTicketRequesterUsersListsResult.Count;
            }
            catch (System.Exception authenticationconnGetTicketRequesterUsersListsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load TicketRequesterUsersLists" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Cpdhelpdesk.Models.Authenticationconn.TicketRequesterUsersList> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditTicketRequesterUsersList>("Edit Ticket Requester Users List", new Dictionary<string, object>() { {"TicketRequesterUser", args.Data.TicketRequesterUser} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteTicketRequesterUsersListResult = await Authenticationconn.DeleteTicketRequesterUsersList(ticketRequesterUser:$"{data.TicketRequesterUser}");
                    if (authenticationconnDeleteTicketRequesterUsersListResult != null && authenticationconnDeleteTicketRequesterUsersListResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (authenticationconnDeleteTicketRequesterUsersListResult != null && authenticationconnDeleteTicketRequesterUsersListResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete TicketRequesterUsersList" });
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteTicketRequesterUsersListException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete TicketRequesterUsersList" });
            }
        }
    }
}
