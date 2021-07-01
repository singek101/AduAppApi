using Aduaba.Data;
using Aduaba.DTO.Product;
using Aduaba.DTOPresentation;
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
        public string AddProduct(AddProductRequest model)
        {
            var productExist = _context.Products.FirstOrDefault(c => c.Name == model.Name);
            if (productExist != null)
            {
                return "Product already exist, Please check the name of the Product";
            }
            _context.Products.Add(new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Quantity = model.Quantity,
                DateAdded = model.DateAdded = DateTime.UtcNow,
                CategoryId=model.CategoryId


            }); ;
            _context.SaveChanges();
            return "Product Added";
        }

        public List<ProductView> GetAllProducts()
        {
            List<ProductView> listOfProducts = new List<ProductView>();
            List<Product> availableProducts = _context.Products.ToList();
           
            foreach (var product in availableProducts)
            {
                listOfProducts.Add(new ProductView()
                {
                    Id=product.Id,
                    Name=product.Name,
                    Description=product.Description,
                    Price=product.Price,
                    ImageUrl=product.ImageUrl                   
                });

            }
            return listOfProducts;


        }
        public ProductView GetProductById(string id)
        {
            var foundProduct = _context.Products.FirstOrDefault(p =>p.Id==id);
            ProductView product = (new ProductView()
            {
                Id=foundProduct.Id,
                Name = foundProduct.Name,
                Description=foundProduct.Description,
                ImageUrl=foundProduct.ImageUrl,
                CategoryId=foundProduct.CategoryId
                
            });
            return product;
        }
        

        public string UpdateProduct(EditProductRequest model)
        {
            var oldProduct = _context.Products.FirstOrDefault(c => c.Id == model.Id);

            if (oldProduct == null)
            {
                return "Product not found";
            } //Category not found


            

            return "Category name updated";

        }
       //// public bool SaveChanges()
       // {
       //     return (_context.SaveChanges() >= 0);
       // }
            public string DeleteProduct(List<string> productIds)
            {
                List<Product> productsToDelete = new List<Product>();

                productsToDelete = _context.Products.Where(c => productIds.Contains(c.Id)).ToList();

                if (productsToDelete.Count != 0)
                {
                    _context.Products.RemoveRange(productsToDelete);
                    _context.SaveChanges();

                    return "Product Deleted Succesfully";
                }

                return "Product doesn't exist";
            }
        }

        
    }

