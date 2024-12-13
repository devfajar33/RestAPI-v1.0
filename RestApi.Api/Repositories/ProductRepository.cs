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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.FromSqlRaw("GetProduct").ToListAsync();
        }
    }
}