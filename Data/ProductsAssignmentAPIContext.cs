using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAssignmentAPI.Models;

namespace ProductsAssignmentAPI.Data
{
    public class ProductsAssignmentAPIContext : DbContext
    {
        public ProductsAssignmentAPIContext (DbContextOptions<ProductsAssignmentAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProductsAssignmentAPI.Models.ProductType> ProductType { get; set; }
    }
}
