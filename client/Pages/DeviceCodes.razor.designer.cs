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
    public partial class DeviceCodesComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.DeviceCode> grid0;

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

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.DeviceCode> _getDeviceCodesResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.DeviceCode> getDeviceCodesResult
        {
            get
            {
                return _getDeviceCodesResult;
            }
            set
            {
                if (!object.Equals(_getDeviceCodesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDeviceCodesResult", NewValue = value, OldValue = _getDeviceCodesResult };
                    _getDeviceCodesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getDeviceCodesCount;
        protected int getDeviceCodesCount
        {
            get
            {
                return _getDeviceCodesCount;
            }
            set
            {
                if (!object.Equals(_getDeviceCodesCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getDeviceCodesCount", NewValue = value, OldValue = _getDeviceCodesCount };
                    _getDeviceCodesCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddDeviceCode>("Add Device Code", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Authenticationconn.ExportDeviceCodesToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "UserCode,DeviceCode1,SubjectId,SessionId,ClientId,Description,CreationTime,Expiration,Data" }, $"Device Codes");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Authenticationconn.ExportDeviceCodesToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "UserCode,DeviceCode1,SubjectId,SessionId,ClientId,Description,CreationTime,Expiration,Data" }, $"Device Codes");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetDeviceCodesResult = await Authenticationconn.GetDeviceCodes(filter:$@"(contains(UserCode,""{search}"") or contains(DeviceCode1,""{search}"") or contains(SubjectId,""{search}"") or contains(SessionId,""{search}"") or contains(ClientId,""{search}"") or contains(Description,""{search}"") or contains(Data,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getDeviceCodesResult = authenticationconnGetDeviceCodesResult.Value.AsODataEnumerable();

                getDeviceCodesCount = authenticationconnGetDeviceCodesResult.Count;
            }
            catch (System.Exception authenticationconnGetDeviceCodesException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load DeviceCodes" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Cpdhelpdesk.Models.Authenticationconn.DeviceCode> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditDeviceCode>("Edit Device Code", new Dictionary<string, object>() { {"UserCode", args.Data.UserCode} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteDeviceCodeResult = await Authenticationconn.DeleteDeviceCode(userCode:$"{data.UserCode}");
                    if (authenticationconnDeleteDeviceCodeResult != null && authenticationconnDeleteDeviceCodeResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (authenticationconnDeleteDeviceCodeResult != null && authenticationconnDeleteDeviceCodeResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete DeviceCode" });
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteDeviceCodeException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete DeviceCode" });
            }
        }
    }
}
