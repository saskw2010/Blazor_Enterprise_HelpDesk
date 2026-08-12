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
    public partial class UserAuditsComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.UserAudit> grid0;

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

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.UserAudit> _getUserAuditsResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.UserAudit> getUserAuditsResult
        {
            get
            {
                return _getUserAuditsResult;
            }
            set
            {
                if (!object.Equals(_getUserAuditsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getUserAuditsResult", NewValue = value, OldValue = _getUserAuditsResult };
                    _getUserAuditsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getUserAuditsCount;
        protected int getUserAuditsCount
        {
            get
            {
                return _getUserAuditsCount;
            }
            set
            {
                if (!object.Equals(_getUserAuditsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getUserAuditsCount", NewValue = value, OldValue = _getUserAuditsCount };
                    _getUserAuditsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddUserAudit>("Add User Audit", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Authenticationconn.ExportUserAuditsToCSV(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "UserAuditId,UserId,Timestamp,AuditEvent,IpAddress" }, $"User Audits");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Authenticationconn.ExportUserAuditsToExcel(new Query() { Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "UserAuditId,UserId,Timestamp,AuditEvent,IpAddress" }, $"User Audits");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetUserAuditsResult = await Authenticationconn.GetUserAudits(filter:$@"(contains(UserId,""{search}"") or contains(AuditEvent,""{search}"") or contains(IpAddress,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getUserAuditsResult = authenticationconnGetUserAuditsResult.Value.AsODataEnumerable();

                getUserAuditsCount = authenticationconnGetUserAuditsResult.Count;
            }
            catch (System.Exception authenticationconnGetUserAuditsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load UserAudits" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<Cpdhelpdesk.Models.Authenticationconn.UserAudit> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditUserAudit>("Edit User Audit", new Dictionary<string, object>() { {"UserAuditId", args.Data.UserAuditId} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var authenticationconnDeleteUserAuditResult = await Authenticationconn.DeleteUserAudit(userAuditId:data.UserAuditId);
                    if (authenticationconnDeleteUserAuditResult != null && authenticationconnDeleteUserAuditResult.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        await grid0.Reload();
                    }

                    if (authenticationconnDeleteUserAuditResult != null && authenticationconnDeleteUserAuditResult.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete UserAudit" });
                    }
                }
            }
            catch (System.Exception authenticationconnDeleteUserAuditException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete UserAudit" });
            }
        }
    }
}
