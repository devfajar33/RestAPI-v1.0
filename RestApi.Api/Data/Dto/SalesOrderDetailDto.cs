using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data.Entity;

namespace RestApi.Api.Data.Dto
{
    public class SalesOrderDetailDto
    {
        public string Id { get; set; }
        public string SalesOrderNo { get; set; }
        public string ProductCode { get; set; } 
        public int Qty  { get; set; }
        public decimal Price  { get; set; }
    }
}