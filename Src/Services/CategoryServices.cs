using Aduaba.Data;
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
        public IEnumerable<Category> GetAllCategories()
        {
            var allCategories = _context.Categories.ToList();
            return allCategories;
        }
            
    }
}
