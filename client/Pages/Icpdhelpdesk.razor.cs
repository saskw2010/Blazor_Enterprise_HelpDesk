using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using Cpdhelpdesk.Client.Pages;

namespace Cpdhelpdesk.Pages
{
    public partial class IcpdhelpdeskComponent
    {
        [Inject]
        protected Microsoft.Extensions.Localization.IStringLocalizer<Icpdhelpdesk> Loc { get; set; }
    }
}
