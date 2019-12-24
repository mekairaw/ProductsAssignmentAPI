using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAssignmentAPI.Domain.Models;
using ProductsAssignmentAPI.Domain.Resources;
using ProductsAssignmentAPI.Domain.Services;
using AutoMapper;

namespace ProductsAssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        //private readonly ProductsAssignmentAPIContext _context;
        private readonly IProductTypeService _productTypeService;
        private readonly IMapper _mapper;

        public ProductTypesController(IProductTypeService productTypeService, IMapper mapper)
        {
            _productTypeService = productTypeService;
            _mapper = mapper;
        }

        // GET: api/ProductTypes
        [HttpGet]
        public async Task<IEnumerable<ProductTypeResource>> GetAllAsync()
        {
            var productTypes = await _productTypeService.ListProductTypesAsync();
            var resources = _mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeResource>>(productTypes);
            return resources;
        }
    }
}
