using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Areas.Admin.Models.Posts
{
    public class CreatePostViewModel
    {
        [Display(Name = "Select category")]
        [Required(ErrorMessage = "Pleas Enter {0}")]
        public int CategoryId { get; set; }
        [Display(Name = "Select Category")]
        [Required(ErrorMessage = "Plaes Enter{0}")]
        public int SubCategory { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Pleas Enter {0}")]
        public string Title { get; set; }
        [Display(Name = "Slug")]
        [Required(ErrorMessage = "Pleas Enter {0}")]
        public string Slug { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Pleas Enter {0}")]
        [UIHint("Ckeditor4")]
        public string Description { get; set; }
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Pleas Enter {0}")]
        public IFormFile ImageFile { get; set; }
        [Display(Name = "IsSpecil!")]
        public bool IsSpecial { get; set; }
    }
}
