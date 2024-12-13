using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data.Dto;
using RestApi.Api.Data.Entity;

namespace RestApi.Api.Mapper
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product _product)
        {
            return new ProductDto
            {
                ProductCode = _product.ProductCode,
                ProductName = _product.ProductName,
            };
        }
    }
}