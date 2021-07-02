using Aduaba.DTOPresentation;
using Aduaba.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryService;
        

        public CategoriesController(ICategoryServices categoryService)
        {
            _categoryService = categoryService;
            
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var result = _categoryService.GetAllCategories();
            if (result == null)
            {
                return NotFound("No categories available");
            }
            return Ok(result);
        }

        [HttpGet ("find-by-name")]
        public IActionResult GetCategoriesByName(string name)
        {
            var result = _categoryService.GetCategoryByName(name);
            if (result == null)
            {
                return NotFound("Category not found");
            }
            return Ok(result);
        }

       
    }
}
