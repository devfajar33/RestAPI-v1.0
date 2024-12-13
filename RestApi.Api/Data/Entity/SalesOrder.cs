using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Api.Data.Entity
{
    public class SalesOrder
    {
        [Key]  // Explicitly marks the Id as the primary key
        public string SalesOrderNo { get; set; }
        public DateTime OrderDate { get; set; } 
        public string CustCode { get; set; }
        public List<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}