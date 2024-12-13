using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data.Entity;

namespace RestApi.Api.Data.Dto
{
    public class SalesOrderDto
    {
        public DateTime OrderDate { get; set; }
        public string SalesOrderNo { get; set; }
        public string CustCode { get; set; }
        public List<SalesOrderDetailDto> SalesOrderDetail { get; set; }
    }
}