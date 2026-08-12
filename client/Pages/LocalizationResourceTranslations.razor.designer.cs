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
    public partial class LocalizationResourceTranslationsComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation> grid0;

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

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation> _getLocalizationResourceTranslationsResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation> getLocalizationResourceTranslationsResult
        {
            get
            {
                return _getLocalizationResourceTranslationsResult;
            }
            set
            {
                if (!object.Equals(_getLocalizationResourceTranslationsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLocalizationResourceTranslationsResult", NewValue = value, OldValue = _getLocalizationResourceTranslationsResult };
                    _getLocalizationResourceTranslationsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getLocalizationResourceTranslationsCount;
        protected int getLocalizationResourceTranslationsCount
        {
            get
            {
                return _getLocalizationResourceTranslationsCount;
            }
            set
            {
                if (!object.Equals(_getLocalizationResourceTranslationsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLocalizationResourceTranslationsCount", NewValue = value, OldValue = _getLocalizationResourceTranslationsCount };
                    _getLocalizationResourceTranslationsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddLocalizationResourceTranslation>("Add Localization Resource Translation", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Authenticationconn.ExportLocalizationResourceTranslationsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "LocalizationResource", Select = "Id,Language,LocalizationResource.Author as LocalizationResourceAuthor,Value,ModificationDate" }, $"Localization Resource Translations");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Authenticationconn.ExportLocalizationResourceTranslationsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "LocalizationResource", Select = "Id,Language,LocalizationResource.Author as LocalizationResourceAuthor,Value,ModificationDate" }, $"Localization Resource Translations");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetLocalizationResourceTranslationsResult = await Authenticationconn.GetLocalizationResourceTranslations(filter:$@"(contains(Language,""{search}"") or contains(Value,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", expand:$"LocalizationResource", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getLocalizationResourceTranslationsResult = authenticationconnGetLocalizationResourceTranslationsResult.Value.AsODataEnumerable();

                getLocalizationResourceTranslationsCount = authenticationconnGetLocalizationResourceTranslationsResult.Count;
            }
            catch (System.Exception authenticationconnGetLocalizationResourceTranslationsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load LocalizationResourceTranslations" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditLocalizationResourceTranslation>("Edit Localization Resource Translation", new Dictionary<string, object>() { {"Id", args.Data.Id} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteLocalizationResourceTranslationResult = await Authenticationconn.DeleteLocalizationResourceTranslation(id:data.Id);
                    if (authenticationconnDeleteLocalizationResourceTranslationResult != null && authenticationconnDeleteLocalizationResourceTranslationResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (authenticationconnDeleteLocalizationResourceTranslationResult != null && authenticationconnDeleteLocalizationResourceTranslationResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete LocalizationResourceTranslation" });
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteLocalizationResourceTranslationException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete LocalizationResourceTranslation" });
            }
        }
    }
}
