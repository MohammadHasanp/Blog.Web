using Blog.CoreLayer.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Blog.CoreLayer.Dtos.User;
using Blog.DataLayer.Context;
using System.Linq;
using CodeYad_Blog.CoreLayer.Utilities;

namespace Blog.Web.Pages.Auth
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class RegisterModel : PageModel
    {
        private readonly IUserServices _userServices;
        public RegisterModel(IUserServices userServices)
        {
            _userServices = userServices;
          
        }

        #region Properties
        [Display(Name ="FullName")]
        [Required(ErrorMessage ="{0}را وارد کنید ")]
        public string FullName { get; set; }
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "{0}را وارد کنید ")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0}را وارد کنید ")]
        [MinLength(6,ErrorMessage ="{0}باید بیشتر از 6 کاراکتر باشد ")]
        public string Password { get; set; }

        #endregion
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            OperationResult Result = _userServices.RegisterUser(new UserRegisterDto()
            {
                FullName = FullName,
                UserName = UserName,
                Password = Password,
            });
            if (Result.Status ==OperationResultStatus.Error)
            {
                ModelState.AddModelError("FullName", Result.Message);
                return Page();
            }

            else
            return RedirectToPage("Login");
        }
    }
}
