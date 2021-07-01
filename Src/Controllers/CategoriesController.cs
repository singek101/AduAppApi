using Aduaba.DTOPresentation;
using Aduaba.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _service;

        public CategoriesController(ICategoryServices service)
        {
            _service = service;
        }
    }
}
