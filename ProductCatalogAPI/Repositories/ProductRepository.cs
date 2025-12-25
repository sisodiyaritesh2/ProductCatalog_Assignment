using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Models;

namespace ProductCatalogAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductCatalogDbContext _context;

        public ProductRepository(ProductCatalogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> FilterByCategoryAsync(string category)
        {
            return await _context.Products
                .Where(p => p.Category != null && p.Category.ToLower() == category.ToLower())
                .ToListAsync();
        }

        public async Task<List<Product>> SearchAsync(string term)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(term) || (p.Description ?? "").Contains(term))
                .ToListAsync();
        }

        public async Task<List<Product>> FilterByPriceRangeAsync(decimal min, decimal max)
        {
            return await _context.Products
                .Where(p => p.Price >= min && p.Price <= max)
                .ToListAsync();
        }
    }
}
