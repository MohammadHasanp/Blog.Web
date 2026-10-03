using Blog.CoreLayer.Services.Category;
using Blog.CoreLayer.Dtos.Categoryes;
using Blog.Web.Areas.Admin.Models.Categoryes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Routing;
using System.Runtime;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController :  AdminControllerBace
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices category)
        {
            _categoryServices = category;
        }
        public IActionResult  Index()
        {
            return View(_categoryServices.GetAllCategory());
        }
        [HttpGet]
        [Route("/admin/category/Add/{ParentId?}")]
        public IActionResult Add(int?parentId)
        {
            var model = new CreateCategoryViewModel
            {
                ParentId = parentId
            };
            return View(model);
        }
        [HttpPost("/admin/category/Add/{ParentId?}")]
        public IActionResult Add(CreateCategoryViewModel create,int? parentid)
        {
            var res=_categoryServices.CreateCategory(create.Map());
            if (res.Status==CodeYad_Blog.CoreLayer.Utilities.OperationResultStatus.Error)
            {
                ModelState.AddModelError(nameof(create.Slug), res.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryServices.GetCategoryDto(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var model = new EditCategoryViewModel()
                {
                    Slug = category.Slug.ToSlug(),
                    MetaDescription = category.MetaDescription,
                    Metatag = category.MetaTag,
                    Title = category.Title

                };
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,EditCategoryViewModel edit)
        {
            var result = _categoryServices.EditCategory(new EditCategoryDto()
            {
                Slug = edit.Slug.ToSlug(),
                ID = id,
                MetaDescription = edit.MetaDescription,
                MetaTag = edit.Metatag,
                Title = edit.Title
            });
            if (result.Status !=CodeYad_Blog.CoreLayer.Utilities.OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(edit.Slug),result.Message);
                return View();
            }
          
                return RedirectToAction("Index");
            
        }
        public IActionResult GetChildCategoryes(int? parentID)
        {
            var model = _categoryServices.GetChildCategoryes(parentID);

            return new JsonResult(model);
        }
    }
}
