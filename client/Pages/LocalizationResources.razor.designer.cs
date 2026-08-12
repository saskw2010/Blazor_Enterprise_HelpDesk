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
    public partial class LocalizationResourcesComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource> grid0;

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

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource> _getLocalizationResourcesResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource> getLocalizationResourcesResult
        {
            get
            {
                return _getLocalizationResourcesResult;
            }
            set
            {
                if (!object.Equals(_getLocalizationResourcesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLocalizationResourcesResult", NewValue = value, OldValue = _getLocalizationResourcesResult };
                    _getLocalizationResourcesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getLocalizationResourcesCount;
        protected int getLocalizationResourcesCount
        {
            get
            {
                return _getLocalizationResourcesCount;
            }
            set
            {
                if (!object.Equals(_getLocalizationResourcesCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLocalizationResourcesCount", NewValue = value, OldValue = _getLocalizationResourcesCount };
                    _getLocalizationResourcesCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddLocalizationResource>("Add Localization Resource", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Authenticationconn.ExportLocalizationResourcesToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "Id,Author,FromCode,IsHidden,IsModified,ModificationDate,ResourceKey,Notes" }, $"Localization Resources");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Authenticationconn.ExportLocalizationResourcesToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "Id,Author,FromCode,IsHidden,IsModified,ModificationDate,ResourceKey,Notes" }, $"Localization Resources");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetLocalizationResourcesResult = await Authenticationconn.GetLocalizationResources(filter:$@"(contains(Author,""{search}"") or contains(ResourceKey,""{search}"") or contains(Notes,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getLocalizationResourcesResult = authenticationconnGetLocalizationResourcesResult.Value.AsODataEnumerable();

                getLocalizationResourcesCount = authenticationconnGetLocalizationResourcesResult.Count;
            }
            catch (System.Exception authenticationconnGetLocalizationResourcesException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load LocalizationResources" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditLocalizationResource>("Edit Localization Resource", new Dictionary<string, object>() { {"Id", args.Data.Id} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteLocalizationResourceResult = await Authenticationconn.DeleteLocalizationResource(id:data.Id);
                    if (authenticationconnDeleteLocalizationResourceResult != null && authenticationconnDeleteLocalizationResourceResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (authenticationconnDeleteLocalizationResourceResult != null && authenticationconnDeleteLocalizationResourceResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete LocalizationResource" });
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteLocalizationResourceException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete LocalizationResource" });
            }
        }
    }
}
