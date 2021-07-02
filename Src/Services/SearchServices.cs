using Aduaba.Data;
using Aduaba.DTOPresentation;
using Aduaba.Models;
using Aduaba.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aduaba.Services
{
    public class SearchServices : ISearchServices
    {
        private readonly ApplicationDbContext _context;

        public SearchServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>>Search(string name)
        {
            IQueryable<Product> query = _context.Products;
            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name)
                || e.Name.Contains(name));
            }

            return await query.ToListAsync();
        }



    }

}
