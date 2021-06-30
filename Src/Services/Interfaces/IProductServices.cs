using Aduaba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Services.Interfaces
{
    public interface IProductServices
    {
        void  AddProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        SubCategory GetCategoryId(int id);
        IEnumerable<Product> GetProductsBySubCategoryId(int id);
        void UpdateProduct(Product product);
        bool SaveChanges();
        void DeleteProduct(Product product);

        
    }
}
