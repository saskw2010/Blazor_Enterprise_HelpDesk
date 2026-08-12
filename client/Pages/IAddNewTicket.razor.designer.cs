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
    public partial class IAddNewTicketComponent : ComponentBase
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

        Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket _helpdeskticket;
        protected Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket helpdeskticket
        {
            get
            {
                return _helpdeskticket;
            }
            set
            {
                if (!object.Equals(_helpdeskticket, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "helpdeskticket", NewValue = value, OldValue = _helpdeskticket };
                    _helpdeskticket = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.LocationList> _getLocationListsForlocationIDResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.LocationList> getLocationListsForlocationIDResult
        {
            get
            {
                return _getLocationListsForlocationIDResult;
            }
            set
            {
                if (!object.Equals(_getLocationListsForlocationIDResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLocationListsForlocationIDResult", NewValue = value, OldValue = _getLocationListsForlocationIDResult };
                    _getLocationListsForlocationIDResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getLocationListsForlocationIDCount;
        protected int getLocationListsForlocationIDCount
        {
            get
            {
                return _getLocationListsForlocationIDCount;
            }
            set
            {
                if (!object.Equals(_getLocationListsForlocationIDCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLocationListsForlocationIDCount", NewValue = value, OldValue = _getLocationListsForlocationIDCount };
                    _getLocationListsForlocationIDCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.ServicesList> _getServicesListsForServiceIDResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.ServicesList> getServicesListsForServiceIDResult
        {
            get
            {
                return _getServicesListsForServiceIDResult;
            }
            set
            {
                if (!object.Equals(_getServicesListsForServiceIDResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getServicesListsForServiceIDResult", NewValue = value, OldValue = _getServicesListsForServiceIDResult };
                    _getServicesListsForServiceIDResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getServicesListsForServiceIDCount;
        protected int getServicesListsForServiceIDCount
        {
            get
            {
                return _getServicesListsForServiceIDCount;
            }
            set
            {
                if (!object.Equals(_getServicesListsForServiceIDCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getServicesListsForServiceIDCount", NewValue = value, OldValue = _getServicesListsForServiceIDCount };
                    _getServicesListsForServiceIDCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _getservicecatlistrowassignTo;
        protected string getservicecatlistrowassignTo
        {
            get
            {
                return _getservicecatlistrowassignTo;
            }
            set
            {
                if (!object.Equals(_getservicecatlistrowassignTo, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getservicecatlistrowassignTo", NewValue = value, OldValue = _getservicecatlistrowassignTo };
                    _getservicecatlistrowassignTo = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _getservicecatlistrowauditcc;
        protected string getservicecatlistrowauditcc
        {
            get
            {
                return _getservicecatlistrowauditcc;
            }
            set
            {
                if (!object.Equals(_getservicecatlistrowauditcc, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getservicecatlistrowauditcc", NewValue = value, OldValue = _getservicecatlistrowauditcc };
                    _getservicecatlistrowauditcc = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist> _getServiceCatglistsForServiceCatgIDResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.ServiceCatglist> getServiceCatglistsForServiceCatgIDResult
        {
            get
            {
                return _getServiceCatglistsForServiceCatgIDResult;
            }
            set
            {
                if (!object.Equals(_getServiceCatglistsForServiceCatgIDResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getServiceCatglistsForServiceCatgIDResult", NewValue = value, OldValue = _getServiceCatglistsForServiceCatgIDResult };
                    _getServiceCatglistsForServiceCatgIDResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getServiceCatglistsForServiceCatgIDCount;
        protected int getServiceCatglistsForServiceCatgIDCount
        {
            get
            {
                return _getServiceCatglistsForServiceCatgIDCount;
            }
            set
            {
                if (!object.Equals(_getServiceCatglistsForServiceCatgIDCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getServiceCatglistsForServiceCatgIDCount", NewValue = value, OldValue = _getServiceCatglistsForServiceCatgIDCount };
                    _getServiceCatglistsForServiceCatgIDCount = value;
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
            helpdeskticket = new Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket(){};

            helpdeskticket.TicketStatus="New";
            helpdeskticket.TicketDate=DateTime.Now;
            helpdeskticket.TicketRequesterUser=Security.User.Name;
            var authenticationconnGetTicketRequesterUsersListResult = await Authenticationconn.GetTicketRequesterUsersListByTicketRequesterUser(Security.User.Name);
            if (authenticationconnGetTicketRequesterUsersListResult != null)
            {
                helpdeskticket.TicketRequesterEmail = authenticationconnGetTicketRequesterUsersListResult.TicketRequesterEmail;
            };
        }

        protected async System.Threading.Tasks.Task Form0Submit(Cpdhelpdesk.Models.Authenticationconn.HelpDeskTicket args)
        {
            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = $"wait", Detail = $"try to update HelpDeskTicket and send email",Duration= 8000 });
                StateHasChanged();
                //await Task.Delay(3000);      // flush changes - show Busy
                //SomeLongSynchronousCode();

            try
            {
                var authenticationconnCreateHelpDeskTicketResult = await Authenticationconn.CreateHelpDeskTicket(helpDeskTicket:helpdeskticket);
                await GlobalsService.SaveTicket(authenticationconnCreateHelpDeskTicketResult.TicketRequesterEmail, authenticationconnCreateHelpDeskTicketResult.TicketGUID, authenticationconnCreateHelpDeskTicketResult.Id, authenticationconnCreateHelpDeskTicketResult.AuditCC, authenticationconnCreateHelpDeskTicketResult.assignTo);
 

  NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Info, Summary = $"done", Detail = $"sended" });

                UriHelper.NavigateTo("i-help-desk-tickets");
            }
            catch (System.Exception authenticationconnCreateHelpDeskTicketException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new HelpDeskTicket!" });
            }
        }

        protected async System.Threading.Tasks.Task LocationIdLoadData(LoadDataArgs args)
        {
            var authenticationconnGetLocationListsResult = await Authenticationconn.GetLocationLists(filter:$"{args.Filter}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:true);
            getLocationListsForlocationIDResult = authenticationconnGetLocationListsResult.Value.AsODataEnumerable();

            getLocationListsForlocationIDCount = authenticationconnGetLocationListsResult.Count;
        }

        protected async System.Threading.Tasks.Task ServiceCatgIdChange(dynamic args)
        {
            if (helpdeskticket.ServiceCatgID!=null)
            {
                var authenticationconnGetServicesListsResult = await Authenticationconn.GetServicesLists(filter:$@"ServiceCatgID eq {helpdeskticket.ServiceCatgID}");
                getServicesListsForServiceIDResult = authenticationconnGetServicesListsResult.Value.AsODataEnumerable();

                getServicesListsForServiceIDCount = authenticationconnGetServicesListsResult.Count;

                if (helpdeskticket.ServiceCatgID!=null)
                {
                    var authenticationconnGetServiceCatglistByServiceCatgIdResult = await Authenticationconn.GetServiceCatglistByServiceCatgId(serviceCatgId:helpdeskticket.ServiceCatgID);
                    getservicecatlistrowassignTo = authenticationconnGetServiceCatglistByServiceCatgIdResult.assignTo;

                    getservicecatlistrowauditcc = authenticationconnGetServiceCatglistByServiceCatgIdResult.AuditCC;
                }

                if (getservicecatlistrowassignTo!=null) {
                    helpdeskticket.assignTo = getservicecatlistrowassignTo;
                }

                if (getservicecatlistrowauditcc!=null) {
                    helpdeskticket.AuditCC = getservicecatlistrowauditcc;
                }
            }
        }

        protected async System.Threading.Tasks.Task ServiceCatgIdLoadData(LoadDataArgs args)
        {
            var authenticationconnGetServiceCatglistsResult = await Authenticationconn.GetServiceCatglists(filter:$"{args.Filter}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:true);
            getServiceCatglistsForServiceCatgIDResult = authenticationconnGetServiceCatglistsResult.Value.AsODataEnumerable();

            getServiceCatglistsForServiceCatgIDCount = authenticationconnGetServiceCatglistsResult.Count;
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("i-help-desk-tickets");
        }
    }
}
