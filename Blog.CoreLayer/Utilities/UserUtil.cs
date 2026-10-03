using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Utilities
{
   public static class UserUtil
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            //return int.Parse(principal.Claims.First(P => P.Type == ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
