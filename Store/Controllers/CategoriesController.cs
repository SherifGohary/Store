using Microsoft.AspNetCore.Mvc;
using Store.Common;
using Store.Entities;
using Store.Services.Interfaces;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public Response<IEnumerable<Category>> GetCategories()
        {
            try
            {
                return new Response<IEnumerable<Category>>
                {
                    Result = _categoryService.GetCategories(),
                    Success = true,
                    Messages = null
                };
            }
            catch(Exception ex)
            {
                return new Response<IEnumerable<Category>>
                {
                    Result = null,
                    Success = false,
                    Messages = new string[] { ex.Message } 
                };
            }
;
        }
    }
}
