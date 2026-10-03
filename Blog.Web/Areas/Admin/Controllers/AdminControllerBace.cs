using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Authorize(Policy = "adminPolicy")]
    [Area( "Admin")]
    public class AdminControllerBace : Controller
    {
      
    }
}
