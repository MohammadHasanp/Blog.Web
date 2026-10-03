using Blog.CoreLayer.Dtos;
using Blog.CoreLayer.Mpperes;
using Blog.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Services.Mainpage
{

    public class MainPageService : IMainPageService
    {
        private readonly BlogContext _context;
        public MainPageService(BlogContext db)
        {
            _context = db;
        }
        public MainPageDto GetData()
        {
            MainPageDto MainPage = new MainPageDto();
            var category = _context.Categories
                .OrderByDescending(c => c.ID)
                .Take(6)
                .Include(c => c.Posts)
                .Include(c => c.SubPosts)
                .Select(c => new MainPageCategoryDto()
                {
                    Title = c.Title,
                    Slug = c.Slug,
                    IsMainCategory = c.ParentId == null,
                    PostChild = c.Posts.Count() + c.SubPosts.Count(),
                }).ToList();


            var specialpost = _context.Posts
                .OrderByDescending(p => p.ID)
                .Include(p => p.Subcategory)
                .Include(p => p.Category)
                .Include(p => p.User)
                .Where(p => p.IsSpecial).Take(4).Select(post => PostMapper.MapGetDtoToPost(post)).ToList();

            var LatesPosts = _context.Posts
                .Include(p => p.Subcategory)
                .Include(P => P.Category)
                .Include(p => p.User)
                .OrderByDescending(p => p.ID)
                .Take(6).Select(post => PostMapper.MapGetDtoToPost(post)).ToList();

            return new MainPageDto()
            {
                Categories = category,
                LatesPost = LatesPosts,
                SpecialPosts = specialpost
            };
        }
    }
}
