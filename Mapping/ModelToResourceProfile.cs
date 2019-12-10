using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductsAssignmentAPI.Domain.Models;
using ProductsAssignmentAPI.Domain.Resources;

namespace ProductsAssignmentAPI.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<ProductType, ProductTypeResource>();
        }
    }
}
