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
    public partial class EditLocalizationResourceTranslationComponent : ComponentBase
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

        [Parameter]
        public dynamic Id { get; set; }

        bool _hasChanges;
        protected bool hasChanges
        {
            get
            {
                return _hasChanges;
            }
            set
            {
                if (!object.Equals(_hasChanges, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "hasChanges", NewValue = value, OldValue = _hasChanges };
                    _hasChanges = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _canEdit;
        protected bool canEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                if (!object.Equals(_canEdit, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "canEdit", NewValue = value, OldValue = _canEdit };
                    _canEdit = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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

        Cpdhelpdesk.Models.Authenticationconn.LocalizationResource _getByLocalizationResourcesForResourceIdResult;
        protected Cpdhelpdesk.Models.Authenticationconn.LocalizationResource getByLocalizationResourcesForResourceIdResult
        {
            get
            {
                return _getByLocalizationResourcesForResourceIdResult;
            }
            set
            {
                if (!object.Equals(_getByLocalizationResourcesForResourceIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getByLocalizationResourcesForResourceIdResult", NewValue = value, OldValue = _getByLocalizationResourcesForResourceIdResult };
                    _getByLocalizationResourcesForResourceIdResult = value;
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
            hasChanges = false;

            canEdit = true;

            var authenticationconnGetLocalizationResourceTranslationByIdResult = await Authenticationconn.GetLocalizationResourceTranslationById(id:Id);
            localizationresourcetranslation = authenticationconnGetLocalizationResourceTranslationByIdResult;

            canEdit = authenticationconnGetLocalizationResourceTranslationByIdResult != null;

            if (this.localizationresourcetranslation.ResourceId != null)
            {
                var authenticationconnGetLocalizationResourceByIdResult = await Authenticationconn.GetLocalizationResourceById(id:this.localizationresourcetranslation.ResourceId);
                getByLocalizationResourcesForResourceIdResult = authenticationconnGetLocalizationResourceByIdResult;
            }
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await this.Load();
        }

        protected async System.Threading.Tasks.Task Form0Submit(Cpdhelpdesk.Models.Authenticationconn.LocalizationResourceTranslation args)
        {
            try
            {
                var authenticationconnUpdateLocalizationResourceTranslationResult = await Authenticationconn.UpdateLocalizationResourceTranslation(id:Id, localizationResourceTranslation:localizationresourcetranslation);
                if (authenticationconnUpdateLocalizationResourceTranslationResult.StatusCode != System.Net.HttpStatusCode.PreconditionFailed) {
                  DialogService.Close(localizationresourcetranslation);
                }

                hasChanges = authenticationconnUpdateLocalizationResourceTranslationResult.StatusCode == System.Net.HttpStatusCode.PreconditionFailed;
            }
            catch (System.Exception authenticationconnUpdateLocalizationResourceTranslationException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update LocalizationResourceTranslation" });

            hasChanges = authenticationconnUpdateLocalizationResourceTranslationException.Message.Contains("412");

            if (!authenticationconnUpdateLocalizationResourceTranslationException.Message.Contains("412")) {
                canEdit = false;
            }
            }
        }

        protected async System.Threading.Tasks.Task ResourceIdLoadData(LoadDataArgs args)
        {
            var authenticationconnGetLocalizationResourcesResult = await Authenticationconn.GetLocalizationResources(filter:$"{args.Filter}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:true);
            getLocalizationResourcesForResourceIdResult = authenticationconnGetLocalizationResourcesResult.Value.AsODataEnumerable();

            getLocalizationResourcesForResourceIdCount = authenticationconnGetLocalizationResourcesResult.Count;
        }

        protected async System.Threading.Tasks.Task Button4Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
