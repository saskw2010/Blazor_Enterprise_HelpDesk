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
    public partial class AddServicesListComponent : ComponentBase
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

        Cpdhelpdesk.Models.Authenticationconn.ServicesList _serviceslist;
        protected Cpdhelpdesk.Models.Authenticationconn.ServicesList serviceslist
        {
            get
            {
                return _serviceslist;
            }
            set
            {
                if (!object.Equals(_serviceslist, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "serviceslist", NewValue = value, OldValue = _serviceslist };
                    _serviceslist = value;
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
            serviceslist = new Cpdhelpdesk.Models.Authenticationconn.ServicesList(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Cpdhelpdesk.Models.Authenticationconn.ServicesList args)
        {
            try
            {
                var authenticationconnCreateServicesListResult = await Authenticationconn.CreateServicesList(servicesList:serviceslist);
                DialogService.Close(serviceslist);
            }
            catch (System.Exception authenticationconnCreateServicesListException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new ServicesList!" });
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
            DialogService.Close(null);
        }
    }
}
