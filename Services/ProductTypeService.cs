using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAssignmentAPI.Domain.Services;
using ProductsAssignmentAPI.Domain.Models;
using ProductsAssignmentAPI.Domain.Repositories;

namespace ProductsAssignmentAPI.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }
        public async Task<IEnumerable<ProductType>> ListProductTypesAsync()
        {
            return await _productTypeRepository.ListProductTypesAsync();
        }
    }
}
