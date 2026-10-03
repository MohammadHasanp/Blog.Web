using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Areas.Admin.Models.Categoryes
{
    public class EditCategoryViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Pleas Enter {0}")]
        public string Title { get; set; }
        [Display(Name = "Slug")]
        [Required(ErrorMessage = "Pleas Enter {0}")]
        public string Slug { get; set; }
        [Display(Name = "MetaTag(Separate with '_')")]
        public string Metatag { get; set; }
        public string MetaDescription { get; set; }
    }
}
