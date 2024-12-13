using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data;

namespace RestApi.Api.Handler
{
    public class GenerateNumber
    {
        private readonly ApplicationDbContext _context;
        public GenerateNumber(ApplicationDbContext context)
        {
            _context = context;
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