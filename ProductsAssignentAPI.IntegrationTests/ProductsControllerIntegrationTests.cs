using ProductsAssignmentAPI;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductsAssignmentAPI.IntegrationTests
{
    public class ProductsControllerIntegrationTests: IClassFixture<ProductsAssignmentTestFactory<Startup>>
    {
        private readonly ProductsAssignmentTestFactory<Startup> _factory;

        public ProductsControllerIntegrationTests(ProductsAssignmentTestFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task GetProducts_WhenCalled_ReturnsNotEmpty()
        {
            //Arrange
            var client = _factory.CreateClient();
            //Act
            var response = await client.GetAsync("/api/products");

            var responseArray = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(responseArray);
        }
    }
}
