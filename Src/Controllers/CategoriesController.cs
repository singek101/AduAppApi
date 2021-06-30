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
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryServices service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
   [HttpGet]
   public ActionResult <IEnumerable<CategoryViewDto>> GetAllCategories()
        {
            var categoryNames = _service.GetAllCategories();
            if(categoryNames !=null)
            {
                return Ok(_mapper.Map<CategoryViewDto>(categoryNames));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
