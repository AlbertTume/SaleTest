using Microsoft.EntityFrameworkCore;
using SaliTest.Application.Interfaces;
using SaliTest.Domain.Entities;

namespace SaliTest.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>?> GetAllProductsAsync()
        {
            try
            {
                var products = await _context.Products
                    .FromSqlRaw("SELECT * FROM fn_get_all_products()")
                    .AsNoTracking()
                    .ToListAsync();
                return products;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<Product?> GetProductByIdAsync(long id)
        {
            try
            {
                var idParam = new Npgsql.NpgsqlParameter("p_product_id", id);
                var product = await _context.Products
                    .FromSqlRaw("SELECT * FROM fn_get_product_by_id(@p_product_id)", idParam)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                return product;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}