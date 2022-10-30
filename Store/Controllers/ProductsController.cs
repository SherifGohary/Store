using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Common;
using Store.Entities;
using Store.Services;
using Store.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public Response<IEnumerable<Product>> GetProducts()
        {
            try
            {
                return new Response<IEnumerable<Product>>
                {
                    Result = _productService.GetProducts(),
                    Success = true,
                    Messages = null
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Product>>
                {
                    Result = null,
                    Success = false,
                    Messages = new string[] { ex.Message }
                };
            }
        }

        [HttpGet, Route("{Id}")]
        public Response<Product> GetProductById(int Id)
        {
            try
            {
                return new Response<Product>
                {
                    Result = _productService.GetProductById(Id),
                    Success = true,
                    Messages = null
                };
            }
            catch (Exception ex)
            {
                return new Response<Product>
                {
                    Result = null,
                    Success = false,
                    Messages = new string[] { ex.Message }

                };
            }
        }

        [HttpGet, Route("GetProductsByCategoryId/{CategoryId}")]
        public Response<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            try
            {
                return new Response<IEnumerable<Product>>
                {
                    Result = _productService.GetProductsByCategoryId(categoryId),
                    Success = true,
                    Messages = null
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Product>>
                {
                    Result = null,
                    Success = false,
                    Messages = new string[] { ex.Message }

                };
            }
        }

        [HttpPost]
        public Response<Product> AddProduct(Product product)
        {
            try
            {
                return new Response<Product>
                {
                    Result = _productService.AddProduct(product),
                    Success = true,
                    Messages = null
                };
            }
            catch (Exception ex)
            {
                return new Response<Product>
                {
                    Result = null,
                    Success = false,
                    Messages = new string[] { ex.Message }

                };
            }
        }

        [HttpPut, Route("{productId}")]
        public Response<Product> UpdateProduct([FromRoute] int productId, [FromBody] Product product)
        {
            try
            {
                return new Response<Product>
                {
                    Result = _productService.UpdateProduct(productId, product),
                    Success = true,
                    Messages = null
                };
            }
            catch (Exception ex)
            {
                return new Response<Product>
                {
                    Result = null,
                    Success = false,
                    Messages = new string[] { ex.Message }

                };
            }
        }
    }
}
