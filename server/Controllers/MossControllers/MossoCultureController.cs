using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Cpdhelpdesk
{
    [Route("[controller]/[action]")]
    public partial class MossoCultureController : Controller
    {
        public IActionResult SetCulture(string culture, string redirectUri)
        {
            if (culture != null)
            {
                HttpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)));
                CultureInfo.CurrentCulture = new RequestCulture(culture).Culture;
                CultureInfo.CurrentUICulture = new RequestCulture(culture).UICulture;


            }

            if (redirectUri == null)
                redirectUri = "/";

                return LocalRedirect(redirectUri);
        }
    }
}
