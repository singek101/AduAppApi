﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.DTOPresentation
{
    public class ProductViewDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
