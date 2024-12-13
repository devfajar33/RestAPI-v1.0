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
    public class PriceRepository : IPriceRepository
    {
        private readonly ApplicationDbContext _context;
        public PriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Prices>> GetAllAsync()
        {
            return await _context.Prices.FromSqlRaw("GetPrice").ToListAsync();
        }
    }
}