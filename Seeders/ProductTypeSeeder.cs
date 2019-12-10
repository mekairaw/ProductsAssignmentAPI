using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAssignmentAPI.Domain.Models;

namespace ProductsAssignmentAPI.Seeders
{
    partial class Seeder
    {
        public static List<ProductType> SeedProductTypes()
        {
            return new List<ProductType>
            {
                new ProductType{Id = 1, Name = "StandAlone"},
                new ProductType{Id = 2, Name = "Bundle"},
            };
        }
    }
}
