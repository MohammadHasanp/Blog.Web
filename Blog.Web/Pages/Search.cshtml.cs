using Blog.CoreLayer.Dtos.Posts;
using Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.PortableExecutable;

namespace Blog.Web.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IPostServices _services;
        public SearchModel(IPostServices post)
        {
            _services = post;
        }
        public PostFilterDto Filter { get; set; }
        public void OnGet(int PageId = 1, string CategorySlug = null, string q = null)
        {
            Filter = _services.PostFilterDto(new PostFilterParams()
            {
                PageId = PageId,
                Take = 2,
                Title = q,
                Slug = CategorySlug,
            });
        }
        public IActionResult OnGetPagination(int PageId = 1, string CategorySlug = null, string q = null)
        {
            var model = _services.PostFilterDto(new PostFilterParams()
            {
                PageId = PageId,
                Take = 2,
                Title = q,
                Slug = CategorySlug,
            });
            return Partial("_SearchView", model: model);
        }
    }
}