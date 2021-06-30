using Aduaba.Data;
using Aduaba.Models;
using Aduaba.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _context;

        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var productsFound = _context.Products.ToList();
            return productsFound;
        }
        public Product GetProductById(int id)
        {
            var foundProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            return foundProduct;
        }
        public IEnumerable<Product> GetProductsBySubCategoryId(int id)
        {
            var productsFound = _context.Products.Where(product => product.SubCategoryId == id).ToList();
            return productsFound;
        }

        public void UpdateProduct(Product product)
        {
            
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void DeleteProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Remove(product);
        }

        public SubCategory GetCategoryId(int id)
        {
            return _context.SubCategories.FirstOrDefault(s => s.Id == id);
        }
    }
}
