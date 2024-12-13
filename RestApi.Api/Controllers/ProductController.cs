using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data.Dto;
using RestApi.Api.Handler;
using RestApi.Api.Interface;
using RestApi.Api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _prodRepo;

        public ProductController(IProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Products = await _prodRepo.GetAllAsync();
            var response = new ApiResponse<List<ProductDto>>
            (
                true, System.Net.HttpStatusCode.OK, "Successfuly", Products.Select(s => s.ToProductDto()).ToList()
            );

            return Ok(response);
        }
    }
}