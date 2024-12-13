using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Api.Data.Dto
{
    public class PriceDto
    {
        public string ProductCode { get; set; }
        public decimal Price{ get; set; }
        public DateTime PriceValidateFrom { get; set; }
        public DateTime PriceValidateTo { get; set; }
    }
}