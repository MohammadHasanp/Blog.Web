using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Areas.Admin.Models.Posts
{
    public class EditPostViewModel
    {
        [Display(Name ="SubCategory")]
        [Required(ErrorMessage ="Pleas Enter{0}")]
        public int? SubCategoryID { get; set; }
        [Display(Name ="Seletct Category")]
        [Required(ErrorMessage ="Pleas Enter {0} ")]
        public int CategoryId { get; set; }
        [Display(Name ="Title")]
        [Required(ErrorMessage ="Pleas Enter {0}")]
        public string Title { get; set; }
        [Display(Name ="Slug")]
        [Required(ErrorMessage ="Pleas Enter {0}")]
        public string Slug { get; set; }
        [Display(Name ="Description")]
        [Required(ErrorMessage ="Pleas Enter {0}")]
        [UIHint("Ckeditor4")]
        public string Description { get; set; }
        [Display(Name ="Imagee")]
        public IFormFile imageFile { get; set; }
        public bool IsSpecial { get; set; }
    }
}
