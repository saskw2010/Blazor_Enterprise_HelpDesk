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
    public partial class MrtcontrollerNamesComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName> grid0;

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

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName> _getMrtcontrollerNamesResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName> getMrtcontrollerNamesResult
        {
            get
            {
                return _getMrtcontrollerNamesResult;
            }
            set
            {
                if (!object.Equals(_getMrtcontrollerNamesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getMrtcontrollerNamesResult", NewValue = value, OldValue = _getMrtcontrollerNamesResult };
                    _getMrtcontrollerNamesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getMrtcontrollerNamesCount;
        protected int getMrtcontrollerNamesCount
        {
            get
            {
                return _getMrtcontrollerNamesCount;
            }
            set
            {
                if (!object.Equals(_getMrtcontrollerNamesCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getMrtcontrollerNamesCount", NewValue = value, OldValue = _getMrtcontrollerNamesCount };
                    _getMrtcontrollerNamesCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddMrtcontrollerName>("Add Mrtcontroller Name", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Authenticationconn.ExportMrtcontrollerNamesToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "controllerNameid,controllerName,ReportCode,Notes,Notes1,mynotes,ModifiedBy,ModifiedOn,CreatedBy,CreatedOn" }, $"Mrtcontroller Names");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Authenticationconn.ExportMrtcontrollerNamesToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "controllerNameid,controllerName,ReportCode,Notes,Notes1,mynotes,ModifiedBy,ModifiedOn,CreatedBy,CreatedOn" }, $"Mrtcontroller Names");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetMrtcontrollerNamesResult = await Authenticationconn.GetMrtcontrollerNames(filter:$@"(contains(controllerName,""{search}"") or contains(ReportCode,""{search}"") or contains(Notes,""{search}"") or contains(Notes1,""{search}"") or contains(mynotes,""{search}"") or contains(ModifiedBy,""{search}"") or contains(CreatedBy,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getMrtcontrollerNamesResult = authenticationconnGetMrtcontrollerNamesResult.Value.AsODataEnumerable();

                getMrtcontrollerNamesCount = authenticationconnGetMrtcontrollerNamesResult.Count;
            }
            catch (System.Exception authenticationconnGetMrtcontrollerNamesException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load MrtcontrollerNames" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Cpdhelpdesk.Models.Authenticationconn.MrtcontrollerName> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditMrtcontrollerName>("Edit Mrtcontroller Name", new Dictionary<string, object>() { {"controllerNameid", args.Data.controllerNameid} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteMrtcontrollerNameResult = await Authenticationconn.DeleteMrtcontrollerName(controllerNameid:data.controllerNameid);
                    if (authenticationconnDeleteMrtcontrollerNameResult != null && authenticationconnDeleteMrtcontrollerNameResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (authenticationconnDeleteMrtcontrollerNameResult != null && authenticationconnDeleteMrtcontrollerNameResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete MrtcontrollerName" });
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteMrtcontrollerNameException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete MrtcontrollerName" });
            }
        }
    }
}
