using Aduaba.DTO.Product;
using Aduaba.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Controllers
{
    [Authorize(Roles ="Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController:ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IProductServices _productservices;

        public AdminController(ICategoryServices categoryServices, IProductServices productservices)
        {
            _categoryServices = categoryServices;
            _productservices = productservices;
        }


        [HttpPost("add-categories")]
        public IActionResult AddCategories(AddCategoryRequest model)
        {
            var result = _categoryServices.AddCategory(model);

            return Ok(result);
        }
        
        [HttpDelete("delete-categories")]
        public IActionResult DeleteCategory(List<string> categoryId)
        {
            var result = _categoryServices.DeleteCategory(categoryId);
            return Ok(result);
        }

        [HttpPut("update-categories")]
        public IActionResult UpdateCategories(EditCategoryRequest model)
        {
           var result= _categoryServices.EditCategory(model);
            return Ok(result);
        }

        [HttpPost("add-products")]
        public IActionResult AddProducts(AddProductRequest model)
        {
            var result = _productservices.AddProduct(model);
            return Ok(result);
        }

        [HttpPut("update-products")]
        public IActionResult UpdateProducts(EditProductRequest model)
        {
            var result = _productservices.UpdateProduct(model);
            return Ok(result);
        }

        [HttpDelete("delete-products")]
        public IActionResult DeleteProducts(List<string> productId)
        {
            var result = _productservices.DeleteProduct(productId);
            return Ok(result);
        }

        [HttpGet("get-productby-id")]
        public IActionResult GetProductById(string id)
        {
            var result = _productservices.GetProductById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("No Product found");
           
        }
    }
}
