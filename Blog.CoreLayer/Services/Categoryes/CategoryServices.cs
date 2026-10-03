using Blog.CoreLayer.Dtos.Categoryes;
using Blog.DataLayer.Context;
using Blog.DataLayer.Entyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DataLayer;
using CodeYad_Blog.CoreLayer.Utilities;
using System.Reflection.Metadata.Ecma335;
using Blog.CoreLayer.Mpperes;
using Blog.CoreLayer.Utilities;

namespace Blog.CoreLayer.Services.Category
{

    public class CategoryServices : ICategoryServices
    {
        private readonly BlogContext _db;

        public CategoryServices(BlogContext context)
        {
            _db = context;
        }

        public OperationResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            if (IsSlugExist(createCategoryDto.Slug))
            {
                return OperationResult.Error("!Is Slug Exist");
            }
            DataLayer.Entyties.Category category;
            try
            {
               category = new DataLayer.Entyties.Category()
                {
                    Title = createCategoryDto.Title,
                    MetaDescription = createCategoryDto.MetaDescription,
                    IsDelete = false,
                    MetaTag = createCategoryDto.MetaTag,
                    ParentId = createCategoryDto.ParentId,
                    Slug = createCategoryDto.Slug.ToSlug(),
                    Time = DateTime.Now,
                };

                _db.Categories.Add(category);
                _db.SaveChanges();
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }

        }

        public OperationResult EditCategory(EditCategoryDto editCategoryDto)
        {
            var category = _db.Categories.FirstOrDefault(c => c.ID == editCategoryDto.ID);
           
            if (category == null)
            {
                return OperationResult.NotFound();
            }
            if (category.Slug != editCategoryDto.Slug.ToSlug())
            {
                if (IsSlugExist(editCategoryDto.Slug))
                {
                    return OperationResult.Error("!Is Slug Exist");
                }
            }

            { 
                category.MetaDescription = editCategoryDto.MetaDescription;
                category.Slug = editCategoryDto.Slug.ToSlug();
                category.Title = editCategoryDto.Title;
                category.MetaTag = editCategoryDto.MetaTag;
                _db.Categories.Update(category);
                _db.SaveChanges();
                return OperationResult.Success();
            }

        }

        public List<GetCategoryDto> GetAllCategory()
        {
            return _db.Categories.Where(c=>c.IsDelete == false).Select(category => CategoryMapper.MapToDto(category)).ToList();
        }

        public GetCategoryDto GetCategoryDto(int Id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.ID == Id);
            if (category == null)
            {
                return null;
            }
            else
            {
                return CategoryMapper.MapToDto(category);
            }

        }

        public GetCategoryDto GetCategoryDto(string slug)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Slug == slug);
            if (category == null)
            {
                return null;
            }
            else
            {
                return CategoryMapper.MapToDto(category);
            }
        }

        public List<GetCategoryDto> GetChildCategoryes(int? parentId)
        {
            return _db.Categories.Where(p => p.ParentId == parentId && p.IsDelete == false).Select(category => CategoryMapper.MapToDto(category)).ToList();
        }

        public bool IsSlugExist(string slug)
        {
            return _db.Categories.Any(s=>s.Slug==slug.ToSlug());
        }
    }
}
