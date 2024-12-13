using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data.Dto;
using RestApi.Api.Data.Entity;
using RestApi.Api.Handler;
using RestApi.Api.Interface;
using RestApi.Api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Api.Controllers
{
    [ApiController]
    [Route("api/salesorder")]
    public class SalesOrderController : ControllerBase
    {
        private readonly ISalesOrderRepository _salesOrderRepo;
        private ApiResponseInsertData _apiResponseInsertData;
        public SalesOrderController(ISalesOrderRepository salesOrderRepo)
        {
            _salesOrderRepo = salesOrderRepo;
            _apiResponseInsertData = new ApiResponseInsertData();
        } 

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var salesOrders = await _salesOrderRepo.GetAllAsync();
            var response = new ApiResponse<List<SalesOrderDto>>
            (
                true, System.Net.HttpStatusCode.OK, "Successfuly", salesOrders.Select(s => s.ToSalesOrderViewDto()).ToList()
            );
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var salesOrder = await _salesOrderRepo.GetByIdAsync(id);
            if(salesOrder == null)
            {
                var notfound = new ApiResponse<List<SalesOrder>>
                (
                    false, System.Net.HttpStatusCode.NotFound, "Data SO nomor '"+id+"' tidak ditemukan", null
                );
                return NotFound(notfound);
            }
            var result = salesOrder.ToSalesOrderViewDto();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SalesOrderDto salesOrderDto)
        {
            var salesOrder = salesOrderDto.ToSoFromCreateDto();
            var message = await _salesOrderRepo.CreateAsync(salesOrder);

            if (message[0] == "1")
            {
                _apiResponseInsertData.StatusCode = System.Net.HttpStatusCode.NotFound;
                _apiResponseInsertData.Status = "failed";
                _apiResponseInsertData.Message = message[1];

                return NotFound(_apiResponseInsertData);
            }

            var SoLatest = await _salesOrderRepo.GetSoLatest();

            _apiResponseInsertData.StatusCode = System.Net.HttpStatusCode.OK;
            _apiResponseInsertData.Status = "success";
            _apiResponseInsertData.SalesOrderNo = SoLatest.SalesOrderNo;
            _apiResponseInsertData.Message = message[1];

            return Ok(_apiResponseInsertData);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] SalesOrderDto salesOrderDto)
        {
            var salesOrder = salesOrderDto.ToSoFromUpdateDto();
            var message = await _salesOrderRepo.UpdateAsync(id, salesOrder);

            if (message[0] == "1")
            {
                _apiResponseInsertData.StatusCode = System.Net.HttpStatusCode.NotFound;
                _apiResponseInsertData.Status = "failed";
                _apiResponseInsertData.Message = message[1];

                return NotFound(_apiResponseInsertData);
            }

            var SoLatest = await _salesOrderRepo.GetSoLatest();

            _apiResponseInsertData.StatusCode = System.Net.HttpStatusCode.OK;
            _apiResponseInsertData.Status = "success";
            _apiResponseInsertData.SalesOrderNo = SoLatest.SalesOrderNo;
            _apiResponseInsertData.Message = message[1];

            return Ok(_apiResponseInsertData);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {            
            var salesOrders = await _salesOrderRepo.DeleteAsync(id);
            if(salesOrders == null)
            {
                var notfound = new ApiResponse<List<SalesOrder>>
                (
                    false, System.Net.HttpStatusCode.NotFound, "Data SO nomor '"+id+"' tidak ditemukan", null
                );
                return NotFound(notfound);
            }

            var result = salesOrders.ToSalesOrderViewDto();            
            return Ok(result);
        }
    }
}