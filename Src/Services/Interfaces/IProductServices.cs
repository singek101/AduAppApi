using Aduaba.DTO.Product;
using Aduaba.DTOPresentation;
using Aduaba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aduaba.Services.Interfaces
{
    public interface IProductServices
    {
        public string AddProduct(AddProductRequest model);
        public ProductView GetProductById(string id);
        public string UpdateProduct(EditProductRequest model);
        public string DeleteProduct(List<string> productIds);





    }
}
