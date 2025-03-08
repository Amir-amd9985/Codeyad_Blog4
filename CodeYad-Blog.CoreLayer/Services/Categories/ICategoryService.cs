using Codeyad_Blog.CoreLayer.DTOs.Categories;
using Codeyad_Blog4.CoreLayer.DTOs.Categories;
using Codeyad_Blog4.CoreLayer.Utilities;

namespace Codeyad_Blog.CoreLayer.Services.Categories
{
    public interface ICategoryService
    {
        OperationResult CreateCategory(CreateCategoryDto command);
        public object CreateCategory(Func<CreateCategoryDto> mapToDto);
        OperationResult EditCategory(EditCategoryDto command);
        List<CategoryDto> GetAllCategory();
        CategoryDto GetCategoryBy(int id);
        CategoryDto GetCategoryBy(string slug);
    }
}