using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAssignmentAPI.Domain.Services;
using ProductsAssignmentAPI.Domain.Models;
using ProductsAssignmentAPI.Domain.Repositories;
using ProductsAssignmentAPI.Services.Communication;

namespace ProductsAssignmentAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Product>> ListProductsAsync()
        {
            return await _productRepository.ListProductsAsync();
        }

        public async Task<SaveProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddProductAsync(product);
                await _unitOfWork.CompleteAsync();

                return new SaveProductResponse();
            }
            catch(Exception ex)
            {
                return new SaveProductResponse($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}
