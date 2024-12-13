using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Api.Data;
using RestApi.Api.Data.Entity;
using RestApi.Api.Interface;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers.FromSqlRaw("GetCustomers").ToListAsync();
        }
    }
}