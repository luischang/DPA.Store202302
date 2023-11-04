using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using DPA.Store.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext storeDbContext)
        {
            _dbContext = storeDbContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext
                            .Product
                            .Where(x => x.IsActive == true)
                            .Include(z => z.Category)
                            .ToListAsync();
        }
    }
}
