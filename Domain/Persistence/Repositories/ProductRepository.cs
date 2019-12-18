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
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> ListProductsAsync()
        {
            return await _context.Products.Include(p => p.ProductType).ToListAsync();
        }
        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<Product> FindById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}
