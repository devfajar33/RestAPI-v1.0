using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Api.Data.Entity
{
    public class Product
    {
        [Key]  // Explicitly marks the Id as the primary key
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}