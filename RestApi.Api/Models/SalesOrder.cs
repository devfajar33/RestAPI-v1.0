using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Api.Models
{
    public class SalesOrder
    {
        public string SalesOrderNo { get; set; }
        public DateTime OrderDate { get; set; } 
        public string CustCode { get; set; }
        public List<SalesOrderDetail> SalesOrderDetail { get; set; }
    }
}