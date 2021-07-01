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

        public Category AddCategory()
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Category UpdateCategories()
        {
            throw new NotImplementedException();
        }
    }
}
