using Codeyad_Blog4.Areas.Admin.Models.Categories;
using Codeyad_Blog4.CoreLayer.DTOs.Categories;
using Codeyad_Blog4.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Codeyad_Blog.CoreLayer.Services.Categories;

namespace Codeyad_Blog4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(categoryService.GetAllCategory());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateCategoryViewModel CreateViewModel)
        {
            var result = categoryService.CreateCategory(CreateViewModel.MapToDto);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var category = categoryService.GetCategoryBy(Id);
            if (category == null)
                return RedirectToAction("Index");

            var model = new EditCategoryViewModel()
            {
                Slug = category.Slug,
                MetaTag = category.MetaTag,
                MetaDescription = category.MetaDescription,
                Title = category.Title
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, EditCategoryViewModel editModel)
        {
            var result = categoryService.EditCategory(new EditCategoryDto()
            {
                Slug = editModel.Slug,
                MetaTag = editModel.MetaTag,
                MetaDescription = editModel.MetaDescription,
                Title = editModel.Title,
                Id = Id
            });

            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(editModel.Slug), result.Message);
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
