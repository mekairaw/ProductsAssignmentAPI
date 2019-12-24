using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAssignmentAPI.Domain.Models;

namespace ProductsAssignmentAPI.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListProductsAsync();
        Task AddProductAsync(Product product);
        Task<Product> FindById(int id);
        void Update(Product product);
        void Remove(Product product);
    }
}
