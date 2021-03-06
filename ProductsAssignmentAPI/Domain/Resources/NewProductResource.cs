﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAssignmentAPI.Domain.Resources
{
    public class NewProductResource
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int ProductTypeId { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }
    }
}
