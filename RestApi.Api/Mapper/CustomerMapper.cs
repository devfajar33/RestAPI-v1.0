using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data.Dto;
using RestApi.Api.Data.Entity;

namespace RestApi.Api.Mapper
{
    public static class CustomerMapper
    {
        public static CustomerDto ToCustomerDto(this Customer _customer)
        {
            return new CustomerDto
            {
                CustId = _customer.CustId,
                CustName = _customer.CustName,
            };
        }
    }
}