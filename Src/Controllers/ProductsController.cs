using Aduaba.DTOPresentation;
using Aduaba.Data;
using Aduaba.Models;
using Aduaba.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Controllers
{
    [Route("api/product")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductsController(IProductServices services)
        {
            _services = services;
        }
        //    [HttpPost]
        //    public IActionResult AddProduct(AddProductDto requestBody)
        //    {
        //        Product product = new Product()
        //        {
        //            Name = requestBody.Name,
        //            Description = requestBody.Description,
        //            Price = requestBody.Price,
        //            ImageUrl = requestBody.ImageUrl,


        //        };
        //        _services.AddProduct(product);
        //        _services.SaveChanges();
        //        return Ok();

        //    }
        //    [HttpGet]
        //    public IActionResult GetAllProducts()
        //    {
        //        List<ProductView> productsFound = new List<ProductView>();
        //        List<Product> products = _services.GetAllProducts().ToList();
        //        if(products.Count == 0)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            foreach(var product in products)
        //            {
        //                productsFound.Add(new ProductView()
        //                {
        //                    Name = product.Name,
        //                    Description = product.Description,
        //                    Price = product.Price,
        //                    ImageUrl = product.ImageUrl
        //                });
        //            }
        //        }
        //        return Ok(productsFound);
        //    }

        //    //[HttpPut("{id}")]
        //    //public IActionResult UpdateProduct(int id, UpdateProductDto updateProductDto)
        //    //{
        //    //    SubCategory subCategory = _services.GetCategoryId(id);
        //    //    List<Product> OldProducts = _services.GetAllProducts().ToList();
        //    //    if (subCategory == null && OldProducts == null)
        //    //    {
        //    //        return NotFound();
        //    //    }

        //    //    //var productsFound = _services.GetProductById(id);
        //    //    //if(productsFound == null)
        //    //    //{
        //    //    //    return NotFound();
        //    //    //}
        //    //    //Product product = new Product()
        //    //    //{
        //    //    //    Name = 
        //    //    //};

        //    //}
        //    [HttpDelete("{id}")]
        //    public IActionResult DeleteProduct(int id)
        //    {
        //        var productToDelete = _services.GetProductById(id);
        //        if(productToDelete == null)
        //        {
        //            return NotFound();
        //        }
        //        _services.DeleteProduct(productToDelete);
        //        _services.SaveChanges();
        //        return NoContent();
        //    }
        //}
    }
}
