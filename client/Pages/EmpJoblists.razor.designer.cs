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
    public partial class EmpJoblistsComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist> grid0;

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

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist> _getEmpJoblistsResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist> getEmpJoblistsResult
        {
            get
            {
                return _getEmpJoblistsResult;
            }
            set
            {
                if (!object.Equals(_getEmpJoblistsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEmpJoblistsResult", NewValue = value, OldValue = _getEmpJoblistsResult };
                    _getEmpJoblistsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getEmpJoblistsCount;
        protected int getEmpJoblistsCount
        {
            get
            {
                return _getEmpJoblistsCount;
            }
            set
            {
                if (!object.Equals(_getEmpJoblistsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEmpJoblistsCount", NewValue = value, OldValue = _getEmpJoblistsCount };
                    _getEmpJoblistsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddEmpJoblist>("Add Emp Joblist", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Authenticationconn.ExportEmpJoblistsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "EmpjoblistID,EmpjoblistDesc,EmpjoblistDesc1" }, $"Emp Joblists");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Authenticationconn.ExportEmpJoblistsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "EmpjoblistID,EmpjoblistDesc,EmpjoblistDesc1" }, $"Emp Joblists");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetEmpJoblistsResult = await Authenticationconn.GetEmpJoblists(filter:$@"(contains(EmpjoblistDesc,""{search}"") or contains(EmpjoblistDesc1,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getEmpJoblistsResult = authenticationconnGetEmpJoblistsResult.Value.AsODataEnumerable();

                getEmpJoblistsCount = authenticationconnGetEmpJoblistsResult.Count;
            }
            catch (System.Exception authenticationconnGetEmpJoblistsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load EmpJoblists" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Cpdhelpdesk.Models.Authenticationconn.EmpJoblist> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditEmpJoblist>("Edit Emp Joblist", new Dictionary<string, object>() { {"EmpjoblistID", args.Data.EmpjoblistID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteEmpJoblistResult = await Authenticationconn.DeleteEmpJoblist(empjoblistId:data.EmpjoblistID);
                    if (authenticationconnDeleteEmpJoblistResult != null && authenticationconnDeleteEmpJoblistResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (authenticationconnDeleteEmpJoblistResult != null && authenticationconnDeleteEmpJoblistResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete EmpJoblist" });
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteEmpJoblistException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete EmpJoblist" });
            }
        }
    }
}
