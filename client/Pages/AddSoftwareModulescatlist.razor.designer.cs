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
    public partial class AddSoftwareModulescatlistComponent : ComponentBase
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

        Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist _softwaremodulescatlist;
        protected Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist softwaremodulescatlist
        {
            get
            {
                return _softwaremodulescatlist;
            }
            set
            {
                if (!object.Equals(_softwaremodulescatlist, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "softwaremodulescatlist", NewValue = value, OldValue = _softwaremodulescatlist };
                    _softwaremodulescatlist = value;
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
            softwaremodulescatlist = new Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist args)
        {
            try
            {
                var authenticationconnCreateSoftwareModulescatlistResult = await Authenticationconn.CreateSoftwareModulescatlist(softwareModulescatlist:softwaremodulescatlist);
                DialogService.Close(softwaremodulescatlist);
            }
            catch (System.Exception authenticationconnCreateSoftwareModulescatlistException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new SoftwareModulescatlist!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
