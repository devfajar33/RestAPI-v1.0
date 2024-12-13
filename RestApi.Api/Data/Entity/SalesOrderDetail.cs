using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Api.Data.Entity
{
    public class SalesOrderDetail
    {
        [Key]
        public int Id { get; set; }
        public string SalesOrderNo { get; set; }
        public string ProductCode { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public SalesOrder SalesOrder { get; set; }
    }
}