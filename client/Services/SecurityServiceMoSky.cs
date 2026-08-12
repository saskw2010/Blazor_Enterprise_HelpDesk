using System;
using System.Collections;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using Cpdhelpdesk.Models;

namespace Cpdhelpdesk
{
    public partial class SecurityService
    {
        public ClaimsPrincipal Principal1 { get; set; }
        public Task Logout()
        {
            throw new NotImplementedException();
        }
        
       
        }

    }

   

