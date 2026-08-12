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
    public partial class AddLocalizationResourceTranslationComponent : ComponentBase
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

        Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation _localizationresourcetranslation;
        protected Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation localizationresourcetranslation
        {
            get
            {
                return _localizationresourcetranslation;
            }
            set
            {
                if (!object.Equals(_localizationresourcetranslation, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "localizationresourcetranslation", NewValue = value, OldValue = _localizationresourcetranslation };
                    _localizationresourcetranslation = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource> _getLocalizationResourcesForResourceIdResult;
        protected IEnumerable<Cpdhelpdesk.Models.Authenticationconn.LocalizationResource> getLocalizationResourcesForResourceIdResult
        {
            get
            {
                return _getLocalizationResourcesForResourceIdResult;
            }
            set
            {
                if (!object.Equals(_getLocalizationResourcesForResourceIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLocalizationResourcesForResourceIdResult", NewValue = value, OldValue = _getLocalizationResourcesForResourceIdResult };
                    _getLocalizationResourcesForResourceIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getLocalizationResourcesForResourceIdCount;
        protected int getLocalizationResourcesForResourceIdCount
        {
            get
            {
                return _getLocalizationResourcesForResourceIdCount;
            }
            set
            {
                if (!object.Equals(_getLocalizationResourcesForResourceIdCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getLocalizationResourcesForResourceIdCount", NewValue = value, OldValue = _getLocalizationResourcesForResourceIdCount };
                    _getLocalizationResourcesForResourceIdCount = value;
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
            localizationresourcetranslation = new Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation args)
        {
            try
            {
                var authenticationconnCreateLocalizationResourceTranslationResult = await Authenticationconn.CreateLocalizationResourceTranslation(localizationResourceTranslation:localizationresourcetranslation);
                DialogService.Close(localizationresourcetranslation);
            }
            catch (System.Exception authenticationconnCreateLocalizationResourceTranslationException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new LocalizationResourceTranslation!" });
            }
        }

        protected async System.Threading.Tasks.Task ResourceIdLoadData(LoadDataArgs args)
        {
            var authenticationconnGetLocalizationResourcesResult = await Authenticationconn.GetLocalizationResources(filter:$"{args.Filter}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:true);
            getLocalizationResourcesForResourceIdResult = authenticationconnGetLocalizationResourcesResult.Value.AsODataEnumerable();

            getLocalizationResourcesForResourceIdCount = authenticationconnGetLocalizationResourcesResult.Count;
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
