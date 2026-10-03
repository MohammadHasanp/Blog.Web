using Blog.CoreLayer.Dtos;
using Blog.CoreLayer.Dtos.Posts;
using Blog.CoreLayer.Services.Mainpage;
using Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Blog.Web.Pages
{
   
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPostServices _servise;
        private IMainPageService _main;
        
        public IndexModel(ILogger<IndexModel> model, IPostServices post,IMainPageService mainPage)
        {
            _logger = model;
            _servise = post;
            _main = mainPage;          
        }
        public MainPageDto mainPageDto { get; set; }
        public void OnGet()
        {
            mainPageDto = _main.GetData();
        }

        public IActionResult OnGetPopularPost()
        {
            return Partial("_PopularPosts", _servise.GetPopularPost());
        }
        public IActionResult OnGetLatestPosts(string categorySlug)
        {
            var filterDto = _servise.PostFilterDto(new PostFilterParams()
            {
                Slug = categorySlug,
                PageId = 1,
                Take = 6,
            });
            return Partial("_LatestPosts", filterDto.Posts);
        }
    }
}
