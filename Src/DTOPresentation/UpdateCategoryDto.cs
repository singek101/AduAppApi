using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.DTOPresentation
{
    public class UpdateCategoryDto
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
