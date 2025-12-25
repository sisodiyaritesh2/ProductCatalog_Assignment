using ProductCatalogAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProductCatalogAPI.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<List<Product>> FilterByCategoryAsync(string category);
        Task<List<Product>> SearchAsync(string term);
        Task<List<Product>> FilterByPriceRangeAsync(decimal min, decimal max);
    }
}
