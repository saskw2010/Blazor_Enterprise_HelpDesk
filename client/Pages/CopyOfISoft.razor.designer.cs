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
    public partial class CopyOfISoftComponent : ComponentBase
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
        protected RadzenDataList<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist> datalist0;

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist> _getsoftcategory;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.SoftwareModulescatlist> getsoftcategory
        {
            get
            {
                return _getsoftcategory;
            }
            set
            {
                if (!object.Equals(_getsoftcategory, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getsoftcategory", NewValue = value, OldValue = _getsoftcategory };
                    _getsoftcategory = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getsoftcatcount;
        protected int getsoftcatcount
        {
            get
            {
                return _getsoftcatcount;
            }
            set
            {
                if (!object.Equals(_getsoftcatcount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getsoftcatcount", NewValue = value, OldValue = _getsoftcatcount };
                    _getsoftcatcount = value;
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

        protected async System.Threading.Tasks.Task Datalist0LoadData(LoadDataArgs args)
        {
            var authenticationconnGetSoftwareModulescatlistsResult = await Authenticationconn.GetSoftwareModulescatlists();
            getsoftcategory = authenticationconnGetSoftwareModulescatlistsResult.Value;

            getsoftcatcount = authenticationconnGetSoftwareModulescatlistsResult.Count;
        }
    }
}
