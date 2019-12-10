using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAssignmentAPI.Domain.Models;
using ProductsAssignmentAPI.Domain.Repositories;
using ProductsAssignmentAPI.Domain.Persistence.Contexts;

namespace ProductsAssignmentAPI.Domain.Persistence.Repositories
{
    public class ProductTypeRepository : BaseRepository, IProductTypeRepository
    {
        public ProductTypeRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<ProductType>> ListProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
