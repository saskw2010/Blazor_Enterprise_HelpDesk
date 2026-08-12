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
    public partial class EmpDepartmentsComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment> grid0;

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

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment> _getEmpDepartmentsResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment> getEmpDepartmentsResult
        {
            get
            {
                return _getEmpDepartmentsResult;
            }
            set
            {
                if (!object.Equals(_getEmpDepartmentsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEmpDepartmentsResult", NewValue = value, OldValue = _getEmpDepartmentsResult };
                    _getEmpDepartmentsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getEmpDepartmentsCount;
        protected int getEmpDepartmentsCount
        {
            get
            {
                return _getEmpDepartmentsCount;
            }
            set
            {
                if (!object.Equals(_getEmpDepartmentsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getEmpDepartmentsCount", NewValue = value, OldValue = _getEmpDepartmentsCount };
                    _getEmpDepartmentsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddEmpDepartment>("Add Emp Department", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Authenticationconn.ExportEmpDepartmentsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "EmpDepartmentID,EmpDepartmentDesc,EmpDepartmentDesc1" }, $"Emp Departments");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Authenticationconn.ExportEmpDepartmentsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "EmpDepartmentID,EmpDepartmentDesc,EmpDepartmentDesc1" }, $"Emp Departments");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetEmpDepartmentsResult = await Authenticationconn.GetEmpDepartments(filter:$@"(contains(EmpDepartmentDesc,""{search}"") or contains(EmpDepartmentDesc1,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getEmpDepartmentsResult = authenticationconnGetEmpDepartmentsResult.Value.AsODataEnumerable();

                getEmpDepartmentsCount = authenticationconnGetEmpDepartmentsResult.Count;
            }
            catch (System.Exception authenticationconnGetEmpDepartmentsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load EmpDepartments" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Cpdhelpdesk.Models.Authenticationconn.EmpDepartment> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditEmpDepartment>("Edit Emp Department", new Dictionary<string, object>() { {"EmpDepartmentID", args.Data.EmpDepartmentID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteEmpDepartmentResult = await Authenticationconn.DeleteEmpDepartment(empDepartmentId:data.EmpDepartmentID);
                    if (authenticationconnDeleteEmpDepartmentResult != null && authenticationconnDeleteEmpDepartmentResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (authenticationconnDeleteEmpDepartmentResult != null && authenticationconnDeleteEmpDepartmentResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete EmpDepartment" });
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteEmpDepartmentException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete EmpDepartment" });
            }
        }
    }
}
