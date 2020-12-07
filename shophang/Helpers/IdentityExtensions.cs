using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Principal;

namespace shophang.Helpers
{
    public static class IdentityExtensions
    {
        public static string GetFirtName(this IPrincipal usr)
        {
            var fullNameClaim = ((ClaimsIdentity)usr.Identity).FindFirst("UserName");
            if (fullNameClaim != null)
                return fullNameClaim.Value;
            return "";
        }
        public static bool IsSignedIn(this IPrincipal usr)
        {
            return usr.Identity.IsAuthenticated;
        }

        public static int Id(this IPrincipal user)
        {
            var idClaim = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim != null)
                return Int32.Parse(idClaim.Value);

            return 0;
        }
    }
}
