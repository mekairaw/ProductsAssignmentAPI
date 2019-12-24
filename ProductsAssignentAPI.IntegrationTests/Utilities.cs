using ProductsAssignmentAPI.Domain.Models;
using ProductsAssignmentAPI.Domain.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsAssignmentAPI.IntegrationTests
{
    public static class Utilities
    {
        public static void InitializeDbWithProducts(AppDbContext db)
        {
            db.Products.AddRange(
            new Product
            {
                Id = 1,
                Name = "Test 1",
                IsActive = true,
                ProductTypeId = 1,
                Price = Convert.ToDecimal(850.35),
                Notes = "Testing",
            },
            new Product
            {
                Id = 2,
                Name = "Test 2",
                IsActive = true,
                ProductTypeId = 1,
                Price = Convert.ToDecimal(586.14),
                Notes = "Testing",
            },
            new Product
            {
                Id = 3,
                Name = "Test 3",
                IsActive = true,
                ProductTypeId = 2,
                Price = Convert.ToDecimal(586.14),
                Notes = "Testing",
            });
            db.SaveChanges();
        }
    }
}
