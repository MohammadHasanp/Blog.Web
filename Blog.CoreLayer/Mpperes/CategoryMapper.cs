using Blog.CoreLayer.Dtos.Categoryes;
using Blog.DataLayer.Entyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Mpperes
{
    public class CategoryMapper
    {
        public static GetCategoryDto MapToDto(Category category)
        {
            return new GetCategoryDto()
            {
                MetaTag = category.MetaTag,
                MetaDescription = category.MetaDescription,
                Title = category.Title,
                Slug = category.Slug,
                ParentId = category.ParentId,
                ID = category.ID
            };
        }
    }
}
