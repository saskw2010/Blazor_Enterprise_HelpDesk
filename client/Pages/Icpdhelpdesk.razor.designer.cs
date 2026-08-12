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
    public partial class IcpdhelpdeskComponent : ComponentBase
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

        string _langauageculture;
        protected string langauageculture
        {
            get
            {
                return _langauageculture;
            }
            set
            {
                if (!object.Equals(_langauageculture, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "langauageculture", NewValue = value, OldValue = _langauageculture };
                    _langauageculture = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _Culture;
        protected string Culture
        {
            get
            {
                return _Culture;
            }
            set
            {
                if (!object.Equals(_Culture, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "Culture", NewValue = value, OldValue = _Culture };
                    _Culture = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _languagename;
        protected string languagename
        {
            get
            {
                return _languagename;
            }
            set
            {
                if (!object.Equals(_languagename, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "languagename", NewValue = value, OldValue = _languagename };
                    _languagename = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _englishname;
        protected string englishname
        {
            get
            {
                return _englishname;
            }
            set
            {
                if (!object.Equals(_englishname, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "englishname", NewValue = value, OldValue = _englishname };
                    _englishname = value;
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
            langauageculture = "";

            Culture = "";

            languagename = "";

            englishname = "";

            langauageculture =System.Globalization.CultureInfo.CurrentCulture.DisplayName;
Culture = await JSRuntime.InvokeAsync<string>("Radzen.getCulture");
languagename=System.Globalization.CultureInfo.CurrentCulture.Name + " - " + System.Globalization.CultureInfo.CurrentCulture.DisplayName;
englishname= Loc["mostafaelnagar"];
        }

        protected async System.Threading.Tasks.Task Button21Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("i-add-new-ticket");
        }

        protected async System.Threading.Tasks.Task Button41Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("services-lists");
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            langauageculture = "";
Culture = "";
languagename = "";
englishname = "";
langauageculture =System.Globalization.CultureInfo.CurrentCulture.DisplayName;
Culture = await JSRuntime.InvokeAsync<string>("Radzen.getCulture");
languagename=System.Globalization.CultureInfo.CurrentCulture.Name + " - " + System.Globalization.CultureInfo.CurrentCulture.DisplayName;
englishname= Loc["mostafaelnagar"];
        }

        protected async System.Threading.Tasks.Task Button31Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("i-help-desk-ticketmasterdetails");
        }

        protected async System.Threading.Tasks.Task Button11Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("i-help-desk-ticketmasterdetailsperuser");
        }

        protected async System.Threading.Tasks.Task Button61Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("i-help-desk-tickets");
        }

        protected async System.Threading.Tasks.Task Button62Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("i-help-desk-ticketwithdetails");
        }

        protected async System.Threading.Tasks.Task Button63Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("ihelpdeskassintome");
        }
    }
}
