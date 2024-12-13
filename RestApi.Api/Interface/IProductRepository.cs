using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data.Entity;

namespace RestApi.Api.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
    }
}