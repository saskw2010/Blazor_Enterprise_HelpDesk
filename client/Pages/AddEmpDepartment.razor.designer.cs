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
    public partial class AddEmpDepartmentComponent : ComponentBase
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

        Cpdhelpdesk.Models.Authenticationconn.EmpDepartment _empdepartment;
        protected Cpdhelpdesk.Models.Authenticationconn.EmpDepartment empdepartment
        {
            get
            {
                return _empdepartment;
            }
            set
            {
                if (!object.Equals(_empdepartment, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "empdepartment", NewValue = value, OldValue = _empdepartment };
                    _empdepartment = value;
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
            empdepartment = new Cpdhelpdesk.Models.Authenticationconn.EmpDepartment(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Cpdhelpdesk.Models.Authenticationconn.EmpDepartment args)
        {
            try
            {
                var authenticationconnCreateEmpDepartmentResult = await Authenticationconn.CreateEmpDepartment(empDepartment:empdepartment);
                DialogService.Close(empdepartment);
            }
            catch (System.Exception authenticationconnCreateEmpDepartmentException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new EmpDepartment!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
