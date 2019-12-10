using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAssignmentAPI.Domain.Models;
using ProductsAssignmentAPI.Domain.Services;

namespace ProductsAssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        //private readonly ProductsAssignmentAPIContext _context;
        private readonly IProductTypeService _productTypeService;

        public ProductTypesController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        // GET: api/ProductTypes
        [HttpGet]
        public async Task<IEnumerable<ProductType>> GetAllAsync()
        {
            return await _productTypeService.ListProductTypesAsync();
        }
    }
}
