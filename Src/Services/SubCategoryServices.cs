using Aduaba.Data;
using Aduaba.Models;
using Aduaba.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Services
{
    public class SubCategoryServices : ISubCategoryServices
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryServices(ApplicationDbContext context)
        {
            _context = context;

        }
  
        public IEnumerable<SubCategory> GetAllSubCategoriesByCategoryId(int id)
        {
            var subCategoriesFound = _context.SubCategories.Where(subcategory => subcategory.categoryId == id).ToList();
            return subCategoriesFound;
            
        }
    }
}
