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
    public partial class IHelpDeskTicketwithdetailsComponent : ComponentBase
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
        protected RadzenDataGrid<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket> grid0;

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket> _getHelpDeskTicketsResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket> getHelpDeskTicketsResult
        {
            get
            {
                return _getHelpDeskTicketsResult;
            }
            set
            {
                if (!object.Equals(_getHelpDeskTicketsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getHelpDeskTicketsResult", NewValue = value, OldValue = _getHelpDeskTicketsResult };
                    _getHelpDeskTicketsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getHelpDeskTicketsCount;
        protected int getHelpDeskTicketsCount
        {
            get
            {
                return _getHelpDeskTicketsCount;
            }
            set
            {
                if (!object.Equals(_getHelpDeskTicketsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getHelpDeskTicketsCount", NewValue = value, OldValue = _getHelpDeskTicketsCount };
                    _getHelpDeskTicketsCount = value;
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

        }

        protected async System.Threading.Tasks.Task Button12Click(MouseEventArgs args)
        {
            await grid0.Reload();
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("add-i-help-desk-ticketwithdetails");
        }

        protected async void Grid0CellRender(DataGridCellRenderEventArgs<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket> args)
        {
            if (args.Data.TicketStatus=="Closed")
                { 
            args.Attributes.Add("style",$"background-color:#d4edda");
            }
            
            if (args.Data.TicketStatus=="New")
                { 
            args.Attributes.Add("style",$"background-color:#f8d7da");
            };
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var authenticationconnGetHelpDeskTicketsResult = await Authenticationconn.GetHelpDeskTickets(filter:$@"contains(assignTo,""{loginuseremail}"") or contains(AuditCC,""{loginuseremail}"")", orderby:$@"{args.OrderBy}", expand:$"HelpDeskTicketDetails,HelpDeskStatus,LocationList,ServiceCatglist,ServicesList", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getHelpDeskTicketsResult = authenticationconnGetHelpDeskTicketsResult.Value.AsODataEnumerable();

                getHelpDeskTicketsCount = authenticationconnGetHelpDeskTicketsResult.Count;
            }
            catch (System.Exception authenticationconnGetHelpDeskTicketsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load HelpDeskTickets" });
            }
        }

        protected async void Grid0Render(DataGridRenderEventArgs<Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket> args)
        {
            if(args.FirstRender)
        {
            args.Grid.Groups.Add(new GroupDescriptor(){ Property = "HelpDeskStatus.TicketStatusDesc" });
            args.Grid.OrderByDescending("Id");
               args.Grid.OrderBy("Id desc");
            StateHasChanged();
            
        };
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket args)
        {
            UriHelper.NavigateTo($"edit-i-help-desk-ticketwithdetails/{args.Id}");
        }
    }
}
