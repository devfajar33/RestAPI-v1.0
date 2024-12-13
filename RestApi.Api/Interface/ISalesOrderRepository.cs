using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data.Dto;
using RestApi.Api.Data.Entity;

namespace RestApi.Api.Interface
{
    public interface ISalesOrderRepository
    {
        Task<List<SalesOrder>> GetAllAsync();
        Task<SalesOrder> GetByIdAsync(string id);
        Task<string[]> CreateAsync(SalesOrder salesOrderModel);
        Task<string[]> UpdateAsync(string id, SalesOrder salesOrderModel);
        Task<SalesOrder?> DeleteAsync(string id);
        Task<SalesOrder> GetSoLatest();
    }
}