using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Api.Data.Entity
{
    public class Prices
    {
        [Key]  // Explicitly marks the Id as the primary key
        public string ProductCode { get; set; }
        public decimal Price{ get; set; }
        public DateTime PriceValidateFrom { get; set; }
        public DateTime PriceValidateTo { get; set; }
    }
}