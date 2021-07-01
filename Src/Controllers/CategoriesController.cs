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
    [Route("api/categories")]
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
            return Ok(result);
        }

       
    }
}
