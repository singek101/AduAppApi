using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.DTOPresentation
{
    public class AddCategoryDto
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
