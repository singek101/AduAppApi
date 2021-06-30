using Aduaba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Services.Interfaces
{
    public interface ISubCategoryServices
    {
        IEnumerable<SubCategory> GetAllSubCategoriesByCategoryId(int id);
    }
}
