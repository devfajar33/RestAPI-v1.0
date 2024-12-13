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
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {            
        private readonly ICustomerRepository _custRepo;

        public CustomerController(ICustomerRepository custRepo)
        {
            _custRepo = custRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _custRepo.GetAllAsync();
            var response = new ApiResponse<List<CustomerDto>>
            (
                true, System.Net.HttpStatusCode.OK, "Successfuly", customers.Select(s => s.ToCustomerDto()).ToList()
            );

            return Ok(response);
        }
    }
}