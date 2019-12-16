using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAssignmentAPI.Domain.Models;

namespace ProductsAssignmentAPI.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListProductsAsync();
    }
}
