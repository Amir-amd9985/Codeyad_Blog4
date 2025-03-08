using System;
using System.Collections.Generic;
using System.Linq;
using Codeyad_Blog4.CoreLayer.Services.Categories;
using Codeyad_Blog4.CoreLayer.DTOs.Categories;
using Codeyad_Blog4.CoreLayer.Mappers;
using Codeyad_Blog4.CoreLayer.Utilities;
using Codeyad_Blog4.DataLayer.Context;
using Codeyad_Blog4.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Codeyad_Blog.CoreLayer.Services.Categories;
using Codeyad_Blog.CoreLayer.DTOs.Categories;

namespace Codeyad_Blog4.CoreLayer.Services.Categories
{

    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateCategory(CreateCategoryDto command)
        {
            var category = new Category()
            {
                Title = command.Title,
                IsDelete = false,
                ParentId = command.ParentId,
                Slug = command.Slug,
                MetaTag = command.MetaTag,
                MetaDescription = command.MetaDescription
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public object CreateCategory(Func<CreateCategoryDto> mapToDto)
        {
            throw new NotImplementedException();
        }

        public OperationResult EditCategory(EditCategoryDto command)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == command.Id);
            if (category == null)
                return OperationResult.NotFound();

            category.MetaDescription = command.MetaDescription;
            category.Slug = command.Slug;
            category.Title = command.Title;
            category.MetaTag = command.MetaTag;

            //_context.Update(category);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<CategoryDto> GetAllCategory()
        {
            return _context.Categories.Select(category => CategoryMapper.Map(category)).ToList();
        }

        public CategoryDto GetCategoryBy(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
                return null;

            return CategoryMapper.Map(category);
        }

        public CategoryDto GetCategoryBy(string slug)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Slug == slug);
            if (category == null)
                return null;
            return CategoryMapper.Map(category);
        }
    }
}