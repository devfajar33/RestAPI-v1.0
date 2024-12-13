using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data.Dto;
using RestApi.Api.Data.Entity;

namespace RestApi.Api.Mapper
{
    public static class SalesOrderMapper
    {
        public static SalesOrderDto ToSalesOrderViewDto(this SalesOrder _salesOrder)
        {
            return new SalesOrderDto
            {
                OrderDate = _salesOrder.OrderDate, 
                SalesOrderNo = _salesOrder.SalesOrderNo,
                CustCode = _salesOrder.CustCode,

                SalesOrderDetail = _salesOrder.SalesOrderDetails.Select(sod => new SalesOrderDetailDto
                {
                    Id = Convert.ToInt16(sod.Id).ToString(),
                    SalesOrderNo = _salesOrder.SalesOrderNo,
                    ProductCode = sod.ProductCode,
                    Qty = sod.Qty,
                    Price = sod.Price
                })
                .ToList()
            };
        }

        public static SalesOrder ToSoFromCreateDto(this SalesOrderDto salesOrderDto)
        {
            return new SalesOrder
            {
                OrderDate = salesOrderDto.OrderDate,
                CustCode = salesOrderDto.CustCode,

                SalesOrderDetails = salesOrderDto.SalesOrderDetail.Select(itemDto => new SalesOrderDetail
                {
                    ProductCode = itemDto.ProductCode,
                    Qty = itemDto.Qty
                })
                .ToList()
            };
        }

        public static SalesOrder ToSoFromUpdateDto(this SalesOrderDto salesOrderDto)
        {
            return new SalesOrder
            {
                OrderDate = salesOrderDto.OrderDate,
                CustCode = salesOrderDto.CustCode,

                SalesOrderDetails = salesOrderDto.SalesOrderDetail.Select(itemDto => new SalesOrderDetail
                {
                    Id = Convert.ToInt16(itemDto.Id),
                    ProductCode = itemDto.ProductCode,
                    Qty = itemDto.Qty
                })
                .ToList()
            };
        }
    }
}