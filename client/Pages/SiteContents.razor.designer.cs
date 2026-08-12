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
    public partial class SiteContentsComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.SiteContent> grid0;

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

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.SiteContent> _getSiteContentsResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.SiteContent> getSiteContentsResult
        {
            get
            {
                return _getSiteContentsResult;
            }
            set
            {
                if (!object.Equals(_getSiteContentsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSiteContentsResult", NewValue = value, OldValue = _getSiteContentsResult };
                    _getSiteContentsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getSiteContentsCount;
        protected int getSiteContentsCount
        {
            get
            {
                return _getSiteContentsCount;
            }
            set
            {
                if (!object.Equals(_getSiteContentsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSiteContentsCount", NewValue = value, OldValue = _getSiteContentsCount };
                    _getSiteContentsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddSiteContent>("Add Site Content", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Authenticationconn.ExportSiteContentsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SiteContentID,FileName,Path,ContentType,Length,Text,Roles,RoleExceptions,Users,UserExceptions,Schedule,ScheduleExceptions,CacheProfile,CreatedDate,ModifiedDate" }, $"Site Contents");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Authenticationconn.ExportSiteContentsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "SiteContentID,FileName,Path,ContentType,Length,Text,Roles,RoleExceptions,Users,UserExceptions,Schedule,ScheduleExceptions,CacheProfile,CreatedDate,ModifiedDate" }, $"Site Contents");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetSiteContentsResult = await Authenticationconn.GetSiteContents(filter:$@"(contains(FileName,""{search}"") or contains(Path,""{search}"") or contains(ContentType,""{search}"") or contains(Text,""{search}"") or contains(Roles,""{search}"") or contains(RoleExceptions,""{search}"") or contains(Users,""{search}"") or contains(UserExceptions,""{search}"") or contains(Schedule,""{search}"") or contains(ScheduleExceptions,""{search}"") or contains(CacheProfile,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getSiteContentsResult = authenticationconnGetSiteContentsResult.Value.AsODataEnumerable();

                getSiteContentsCount = authenticationconnGetSiteContentsResult.Count;
            }
            catch (System.Exception authenticationconnGetSiteContentsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load SiteContents" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Cpdhelpdesk.Models.Authenticationconn.SiteContent> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditSiteContent>("Edit Site Content", new Dictionary<string, object>() { {"SiteContentID", args.Data.SiteContentID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteSiteContentResult = await Authenticationconn.DeleteSiteContent(siteContentId:data.SiteContentID);
                    if (authenticationconnDeleteSiteContentResult != null && authenticationconnDeleteSiteContentResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (authenticationconnDeleteSiteContentResult != null && authenticationconnDeleteSiteContentResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete SiteContent" });
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteSiteContentException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete SiteContent" });
            }
        }
    }
}
