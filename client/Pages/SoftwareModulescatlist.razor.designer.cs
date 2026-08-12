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
    public partial class SoftwareModulescatlistComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist> grid0;

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

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist> _getSoftwareModulescatlistsResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist> getSoftwareModulescatlistsResult
        {
            get
            {
                return _getSoftwareModulescatlistsResult;
            }
            set
            {
                if (!object.Equals(_getSoftwareModulescatlistsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSoftwareModulescatlistsResult", NewValue = value, OldValue = _getSoftwareModulescatlistsResult };
                    _getSoftwareModulescatlistsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getSoftwareModulescatlistsCount;
        protected int getSoftwareModulescatlistsCount
        {
            get
            {
                return _getSoftwareModulescatlistsCount;
            }
            set
            {
                if (!object.Equals(_getSoftwareModulescatlistsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSoftwareModulescatlistsCount", NewValue = value, OldValue = _getSoftwareModulescatlistsCount };
                    _getSoftwareModulescatlistsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddSoftwareModulescatlist>("Add Software Modulescatlist", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetSoftwareModulescatlistsResult = await Authenticationconn.GetSoftwareModulescatlists(filter:$@"(contains(sprModulecatDesc,""{search}"") or contains(sprModulecatDesc1,""{search}"") or contains(FuturecatDesc,""{search}"") or contains(FuturecatDesc1,""{search}"") or contains(photopath,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$@"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getSoftwareModulescatlistsResult = authenticationconnGetSoftwareModulescatlistsResult.Value.AsODataEnumerable();

                getSoftwareModulescatlistsCount = authenticationconnGetSoftwareModulescatlistsResult.Count;
            }
            catch (System.Exception authenticationconnGetSoftwareModulescatlistsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load SoftwareModulescatlists" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist args)
        {
            var dialogResult = await DialogService.OpenAsync<EditSoftwareModulescatlist>("Edit Software Modulescatlist", new Dictionary<string, object>() { {"sprModulecatid", args.sprModulecatid} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteSoftwareModulescatlistResult = await Authenticationconn.DeleteSoftwareModulescatlist(sprModulecatid:data.sprModulecatid);
                    if (authenticationconnDeleteSoftwareModulescatlistResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteSoftwareModulescatlistException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete SoftwareModulescatlist" });
            }
        }
    }
}
