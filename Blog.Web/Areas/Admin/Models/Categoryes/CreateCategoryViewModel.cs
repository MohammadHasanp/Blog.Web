using Blog.CoreLayer.Dtos.Categoryes;
using Blog.DataLayer.Entyties;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Blog.Web.Areas.Admin.Models.Categoryes
{
    public class CreateCategoryViewModel
    {
        [Display(Name ="Title")]
        [Required(ErrorMessage ="Pleas Enter{0}")]
        public string Title { get; set; }
        [Display(Name ="Slug")]
        [Required(ErrorMessage ="Pleas Enter {0}")]
        public string Slug { get; set; }

        [Display(Name = "MetaTag(Separate with '_')")]
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public int? ParentId { get; set; }

        public CreateCategoryDto Map()
        {
            return new CreateCategoryDto
            {
                MetaDescription = MetaDescription,
                MetaTag = MetaTag,
                Slug = Slug,
                Title = Title,
                ParentId = ParentId
            };
        }
    }
}