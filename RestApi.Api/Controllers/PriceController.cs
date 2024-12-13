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
    [Route("api/price")]
    public class PriceController : ControllerBase
    {
        private readonly IPriceRepository _priceRepo;

        public PriceController(IPriceRepository priceRepo)
        {
            _priceRepo = priceRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Prices = await _priceRepo.GetAllAsync();
            var response = new ApiResponse<List<PriceDto>>
            (
                true, System.Net.HttpStatusCode.OK, "Successfuly", Prices.Select(s => s.ToPriceDto()).ToList()
            );

            return Ok(response);
        }
    }
}