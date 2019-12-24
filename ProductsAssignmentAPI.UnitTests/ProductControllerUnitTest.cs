using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAssignmentAPI.Domain.Models;
using ProductsAssignmentAPI.Domain.Persistence.Contexts;
using ProductsAssignmentAPI.Domain.Persistence.Repositories;
using ProductsAssignmentAPI.Domain.Services;
using ProductsAssignmentAPI.Controllers;
using Xunit;
using Moq;
using AutoMapper;
using ProductsAssignmentAPI.Domain.Resources;
using ProductsAssignmentAPI.Mapping;

namespace ProductsAssignmentAPI.UnitTests
{
    public class ProductControllerUnitTest
    {
        [Fact]
        public async Task TestGetProductsAsync_NotEmpty()
        {
            //Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(service => service.ListProductsAsync())
                .ReturnsAsync(GetProductsResult());
            var profile = new ModelToResourceProfile();
            var configProfile = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mockMapper = new Mapper(configProfile);
            var productsController = new ProductsController(mockProductService.Object, mockMapper);
            //Act
            var result = await productsController.GetAllAsync();
            //Assert
            Assert.NotEmpty(result);
        }

        public IEnumerable<Product> GetProductsResult()
        {
            return new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Test 1",
                    IsActive = true,
                    ProductTypeId = 1,
                    Price = Convert.ToDecimal(850.35),
                    Notes = "Testing",
                    ProductType = new ProductType
                    {
                        Id=1,
                        Name="StandAlone"
                    }
                },
                new Product
                {
                    Id = 2,
                    Name = "Test 2",
                    IsActive = true,
                    ProductTypeId = 1,
                    Price = Convert.ToDecimal(586.14),
                    Notes = "Testing",
                    ProductType = new ProductType
                    {
                        Id=1,
                        Name="StandAlone"
                    }
                },
                new Product
                {
                    Id = 3,
                    Name = "Test 3",
                    IsActive = true,
                    ProductTypeId = 2,
                    Price = Convert.ToDecimal(586.14),
                    Notes = "Testing",
                    ProductType = new ProductType
                    {
                        Id=2,
                        Name="Bundle"
                    }
                }
            };
        }
    }
}
