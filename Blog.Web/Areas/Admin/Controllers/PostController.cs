using Blog.CoreLayer.Dtos.Posts;
using Blog.CoreLayer.Services.FileManager;
using Blog.CoreLayer.Services.Posts;
using Blog.CoreLayer.Utilities;
using Blog.Web.Areas.Admin.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using CodeYad_Blog.CoreLayer.Utilities;
using Blog.DataLayer.Entyties;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class PostController : AdminControllerBace
    {
        private IPostServices _PostServices;
        public PostController(IPostServices services)
        {
            _PostServices = services;
        }
        [HttpGet]
        public IActionResult Index(int PageID = 1, string Title = "", string CategorySlug = "")
        {
            var post = new PostFilterParams
            {
                PageId = PageID,
                Slug = CategorySlug,
                Take = 2,
                Title = Title,
            };
            var Model = _PostServices.PostFilterDto(post);
            return View(Model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _PostServices.CreatePost(new CreatePostDto()
            {
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageFile = model.ImageFile,
                Slug = model.Slug,
                SubCategoryID = model.SubCategory == 0 ? null : model.SubCategory,
                Title = model.Title,
                IsSpecial = model.IsSpecial,
                UserId = User.GetUserId()
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(model.Slug), result.Message);
                return View(model);
            }

            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _PostServices.GetPost(id);
            var model = new EditPostViewModel()
            {
                CategoryId = post.CategoryId,
                Description = post.Description,
                Slug = post.Slug,
                SubCategoryID = post.SubCategoryID,
                imageFile = post.ImageFile,
                Title = post.Title,
                IsSpecial = post.IsSpecial,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditPostViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();
            var result = _PostServices.Editpost(new EditPostDto()
            {
                CategoryId = viewModel.CategoryId,
                Description = viewModel.Description,
                imageFile = viewModel.imageFile,
                Slug = viewModel.Slug,
                SubCategoryID = viewModel.SubCategoryID == 0 ? null : viewModel.SubCategoryID,
                Title = viewModel.Title,
                IsSpecial = viewModel.IsSpecial,
                ID = id,
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(viewModel.Slug), result.Message);
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }
    }
}
