using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{

    public class HomeController : AdminControllerBace
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
