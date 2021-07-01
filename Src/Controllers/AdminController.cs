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

        public AdminController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }


        [HttpPost("add-categories")]
        public IActionResult AddCategories(AddCategoryRequest model)
        {
            var result = _categoryServices.AddCategory(model);
            return Ok(result);
        }
        
        [HttpDelete("delete-categories")]
        public IActionResult DeleteCategory(List<String> categoryIds)
        {
            var result = _categoryServices.DeleteCategory(categoryIds);
            return Ok(result);
        }

        [HttpPut("update-categories")]
        public IActionResult UpdateCategories(EditCategoryRequest model)
        {
           var result= _categoryServices.EditCategory(model);
            return Ok(result);
        }
    }
}
