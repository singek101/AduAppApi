using Aduaba.Data;
using Aduaba.DTO.Product;
using Aduaba.DTOPresentation.Product;
using Aduaba.Models;
using Aduaba.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context )
        {
            _context = context;
        }
        public string AddCategory(AddCategoryRequest model)
        {
            var categoryExist = _context.Categories.FirstOrDefault(c => c.CategoryName == model.CategoryName);
            if (categoryExist != null)
            {
                return "Category already exist, Please check the name of the category";
            }
            _context.Categories.Add(new Category()
            {
                Id = Guid.NewGuid().ToString(),
                CategoryName = model.CategoryName
            });
            _context.SaveChanges();
            return "Category Added";
        }

        public List<CategoryView> GetAllCategories()
        {
            List<CategoryView> listOfCategories = new List<CategoryView>();
            List<Category> availableCategories = _context.Categories.ToList();
            foreach (var category in availableCategories)
            {
                listOfCategories.Add(new CategoryView()
                {
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName
                });

            }
            return listOfCategories;


        }
        public CategoryView GetCategoryByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var foundCategory = _context.Categories.FirstOrDefault(c => c.CategoryName == name);
                if (foundCategory == null)
                {
                    return null;
                }
                
                CategoryView category = (new CategoryView()
                {
                    CategoryId = foundCategory.Id,
                    CategoryName=foundCategory.CategoryName,
                    
                    

                });
                return category;
            }
            return null;
        }

        public string DeleteCategory(List<string> names)
        {
            List<Category> categoriesToDelete = new List<Category>();

            categoriesToDelete = _context.Categories.Where(c => names.Contains(c.CategoryName)).ToList();

            if (categoriesToDelete.Count != 0)
            {
                _context.Categories.RemoveRange(categoriesToDelete);
                _context.SaveChanges();

                return "Category Deleted Succesfully";
            }

            return "Category doesn't exist";
        }


        public string  EditCategory(EditCategoryRequest editCategoryRequest)
        {
            var oldCategory = _context.Categories.FirstOrDefault(c => c.Id == editCategoryRequest.Id);

            if (oldCategory == null)
            {
                return "Category not found";
            } //Category not found

            oldCategory.CategoryName = editCategoryRequest.NewCategoryName;
            _context.SaveChanges();
            return "Category name updated";
        }
    }
}
