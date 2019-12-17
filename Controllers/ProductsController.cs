﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAssignmentAPI.Domain.Resources;
using ProductsAssignmentAPI.Domain.Models;
using ProductsAssignmentAPI.Domain.Services;
using ProductsAssignmentAPI.Extensions;
using AutoMapper;

namespace ProductsAssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllAsync()
        {
            var products = await _productService.ListProductsAsync();
            var result = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] NewProductResource newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var product = _mapper.Map<NewProductResource, Product>(newProduct);
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
