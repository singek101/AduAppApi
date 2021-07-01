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
using Microsoft.AspNetCore.Authorization;

namespace Aduaba.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var result = _productServices.GetAllProducts();
            if(result==null)
            {
                return NoContent();

            }
            return Ok(result);
        }

        
        
    }
}
