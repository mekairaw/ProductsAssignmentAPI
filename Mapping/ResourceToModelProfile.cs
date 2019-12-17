using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAssignmentAPI.Domain.Models;
using ProductsAssignmentAPI.Domain.Resources;
using AutoMapper;

namespace ProductsAssignmentAPI.Mapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<NewProductResource, Product>();
        }
    }
}
