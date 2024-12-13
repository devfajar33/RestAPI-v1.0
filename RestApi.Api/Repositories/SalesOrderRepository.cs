using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data;
using RestApi.Api.Data.Entity;
using RestApi.Api.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Api.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public SalesOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalesOrder>> GetAllAsync()
        {
            var salesOrders = await _context.SalesOrders.Include(so => so.SalesOrderDetails).ToListAsync();
            return salesOrders;
        }

        public async Task<SalesOrder> GetByIdAsync(string id)
        {
            return await _context.SalesOrders.Include(so => so.SalesOrderDetails).FirstOrDefaultAsync(so => so.SalesOrderNo == id); 
        }

        public async Task<string[]> CreateAsync(SalesOrder SoModel)
        {
            var number = GenerateCustomerNumber();

            var salesOrderTable = new DataTable();
            salesOrderTable.Columns.Add("ProdCode", typeof(string));
            salesOrderTable.Columns.Add("Qty", typeof(int));

            var Param = new SqlParameter("@Param", SqlDbType.NVarChar, 1)
            {
                Direction = ParameterDirection.Output
            };

            var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 100)
            {
                Direction = ParameterDirection.Output
            };

            foreach (var item in SoModel.SalesOrderDetails)
            {
                salesOrderTable.Rows.Add(item.ProductCode, item.Qty);
            }

            var currentDateParam = new SqlParameter("@currentDate", SqlDbType.NVarChar) { Value = SoModel.OrderDate };
            var SoNumberParam = new SqlParameter("@SoNumber", SqlDbType.NVarChar) { Value = number };
            var CustCodeParam = new SqlParameter("@CustCode", SqlDbType.NVarChar) { Value = SoModel.CustCode };
            var SoItemsParam = new SqlParameter("@SalesOrderItemType", SqlDbType.Structured)
            {
                TypeName = "SalesOrderItemType",
                Value = salesOrderTable
            };

            _context.Database.ExecuteSqlRaw("EXEC InsertSalesOrder @currentDate, @SoNumber, @CustCode, @SalesOrderItemType, @Param OUTPUT, @Message OUTPUT", 
            currentDateParam, SoNumberParam, CustCodeParam, SoItemsParam, Param, messageParam);

            string? param_ = Param.Value.ToString();
            string? message_ = messageParam.Value.ToString();

            return new string[] { param_, message_ };
        }

        public async Task<string[]> UpdateAsync(string id, SalesOrder SoModel)
        {
            var salesOrderTable = new DataTable();
            salesOrderTable.Columns.Add("Id", typeof(string));
            salesOrderTable.Columns.Add("ProdCode", typeof(string));
            salesOrderTable.Columns.Add("Qty", typeof(int));

            var Param = new SqlParameter("@Param", SqlDbType.NVarChar, 1)
            {
                Direction = ParameterDirection.Output
            };

            var messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 100)
            {
                Direction = ParameterDirection.Output
            };

            foreach (var item in SoModel.SalesOrderDetails)
            {
                salesOrderTable.Rows.Add(item.Id, item.ProductCode, item.Qty);
            }

            var currentDateParam = new SqlParameter("@currentDate", SqlDbType.NVarChar) { Value = SoModel.OrderDate };
            var SoNumberParam = new SqlParameter("@SoNumber", SqlDbType.NVarChar) { Value = id };
            var CustCodeParam = new SqlParameter("@CustCode", SqlDbType.NVarChar) { Value = SoModel.CustCode };
            var SoItemsParam = new SqlParameter("@SalesOrderItemType", SqlDbType.Structured)
            {
                TypeName = "SalesOrderItemUpdateType",
                Value = salesOrderTable
            };

            _context.Database.ExecuteSqlRaw("EXEC UpdateSalesOrder @currentDate, @SoNumber, @CustCode, @SalesOrderItemType, @Param OUTPUT, @Message OUTPUT", 
            currentDateParam, SoNumberParam, CustCodeParam, SoItemsParam, Param, messageParam);

            string? param_ = Param.Value.ToString();
            string? message_ = messageParam.Value.ToString();

            return new string[] { param_, message_ };
        }

        public async Task<SalesOrder?> DeleteAsync(string id)
        {
            var itemModel = await _context.SalesOrders.FirstOrDefaultAsync(x => x.SalesOrderNo == id);
            var itemModelDetail = await _context.SalesOrderDetails.Where(d => d.SalesOrderNo == id).ToListAsync();

            if(itemModel == null) 
            {
                return null;
            }

            _context.SalesOrders.Remove(itemModel);
            _context.SalesOrderDetails.RemoveRange(itemModelDetail);

            await _context.SaveChangesAsync();
            return itemModel;
        }

        public async Task<SalesOrder?> GetSoLatest()
        {
            return await _context.SalesOrders.OrderByDescending(c => c.SalesOrderNo).FirstOrDefaultAsync();
        }

        public string GenerateCustomerNumber()
        {
            var lastSO = _context.SalesOrders
                                    .OrderByDescending(c => c.SalesOrderNo)
                                    .FirstOrDefault();

            int nextNumber = 1;

            if (lastSO != null)
            {
                var lastNumber = lastSO.SalesOrderNo;
                var numberPart = lastNumber.Substring(2);
                nextNumber = int.Parse(numberPart) + 1;
            }

            return $"SO{nextNumber:D3}";  // Format nomor seperti 'SO001' dst
        }
    }
}