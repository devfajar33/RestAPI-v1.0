using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data.Dto;
using RestApi.Api.Data.Entity;

namespace RestApi.Api.Mapper
{
    public static class PriceMapper
    {
        public static PriceDto ToPriceDto(this Prices _price)
        {
            return new PriceDto
            {
                ProductCode = _price.ProductCode,
                Price = _price.Price,
                PriceValidateFrom = _price.PriceValidateFrom,
                PriceValidateTo = _price.PriceValidateTo,
            };
        }
    }
}