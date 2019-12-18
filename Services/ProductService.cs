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

        public async Task<SaveProductResponse> UpdateAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.FindById(id);

            if(existingProduct == null)
            {
                return new SaveProductResponse("Producto no encontrado");
            }

            existingProduct.Name = product.Name;
            existingProduct.IsActive = product.IsActive;
            existingProduct.ProductTypeId = product.ProductTypeId;
            existingProduct.Notes = product.Notes;
            existingProduct.Price = product.Price;

            try
            {
                _productRepository.Update(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new SaveProductResponse();
            }
            catch(Exception ex)
            {
                return new SaveProductResponse($"Ha ocurrido un error al actualizar el producto: {ex.Message}");
            }
        }
        public async Task<Product> GetProductAsync(int id)
        {
            var existingroduct = await _productRepository.FindById(id);
            return existingroduct;
        }

        public async Task<DeleteProductResponse> DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepository.FindById(id);
            if(existingProduct == null)
            {
                return new DeleteProductResponse("Producto no encontrado");
            }
            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new DeleteProductResponse();
            }
            catch(Exception ex)
            {
                return new DeleteProductResponse($"Un error ocurrió al momento de borrar el producto: {ex.Message}");
            }
        }
    }
}
