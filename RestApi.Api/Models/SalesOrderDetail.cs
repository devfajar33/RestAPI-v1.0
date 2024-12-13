using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Api.Models
{
    public class SalesOrderDetail
    {
        public string SalesOrderNo { get; set; }
        public string ProductCode { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public SalesOrder SalesOrder { get; set; }
    }
}