using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Cpdhelpdesk.Authentication
{
    public class TokenProviderOptions
    {
        public static string Audience { get; } = "CpdhelpdeskAudience";
        public static string Issuer { get; } = "Cpdhelpdesk";
        public static SymmetricSecurityKey Key { get; } = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("CpdhelpdeskSecretSecurityKeyCpdhelpdesk"));
        public static TimeSpan Expiration { get; } = TimeSpan.FromMinutes(5);
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
    }
}
