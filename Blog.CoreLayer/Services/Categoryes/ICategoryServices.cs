using Blog.CoreLayer.Dtos.Categoryes;
using CodeYad_Blog.CoreLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Services.Category
{
    public interface ICategoryServices
    {
        OperationResult CreateCategory(CreateCategoryDto createCategoryDto);
        OperationResult EditCategory(EditCategoryDto editCategoryDto);
        List<GetCategoryDto>GetAllCategory();
        List<GetCategoryDto>GetChildCategoryes(int? parentId);
        GetCategoryDto GetCategoryDto(int Id);
        GetCategoryDto GetCategoryDto(string slug);
        bool IsSlugExist(string slug);

    }
}
