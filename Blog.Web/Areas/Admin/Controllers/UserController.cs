using Blog.CoreLayer.Dtos.Posts;
using Blog.CoreLayer.Dtos.User;
using Blog.CoreLayer.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private IUserServices _services;
        public UserController(IUserServices userServices)
        {
            _services = userServices;
        }
        public IActionResult Index(int PageID = 1, string fullname = "", string username = "")
        {
            var post = new UserFilter
            {
                PageId = PageID,
                FullName = fullname,
                Take = 2,
                UserName = username,
            };
            var Model = _services.UserFilterDto(post);
            return View(Model);
        }
        [HttpGet]
        public IActionResult ShowEditUser(int userid)
        {
            var user = _services.GetUserById(userid);
            return PartialView("_EditUser", new EditUserDto
            {
                FullNmae = user.FullName,
                Role = user.Role,
                UserId = userid,
                UserName = user.UserName,
            });
        }
        [HttpPost]
        public IActionResult Edit(EditUserDto editUserDto)
        {
            var user = _services.EditUser(editUserDto);
            if(user.Status != CodeYad_Blog.CoreLayer.Utilities.OperationResultStatus.Success)
            {
                return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }
    }
}
