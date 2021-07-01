using Aduaba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Services.Interfaces
{
   public  interface ICategoryServices
    {
        Category AddCategory();
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category UpdateCategories();
        void DeleteCategory();
    }
}
