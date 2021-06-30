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
    [Route("api/subcategories")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryServices _services;
        private readonly IMapper _mapper;

        public SubCategoriesController(ISubCategoryServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<SubCategoryViewDto>> GetAllSubCategoriesByCategoryId(int id )
        {
            var subCategoryNames = _services.GetAllSubCategoriesByCategoryId(id);
            if (subCategoryNames != null)
            {
                return Ok(_mapper.Map<SubCategoryViewDto>(subCategoryNames));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
