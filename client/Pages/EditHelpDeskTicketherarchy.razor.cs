using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;

namespace Cpdhelpdesk.Pages
{
    public partial class EditHelpDeskTicketherarchyComponent
    {
        [Inject]
        protected GlobalsService GlobalsService { get; set; }
    }
}
