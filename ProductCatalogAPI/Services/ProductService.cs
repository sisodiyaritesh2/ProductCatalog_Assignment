using ProductCatalogAPI.Models;
using ProductCatalogAPI.Repositories;

namespace ProductCatalogAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Product>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Product?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<List<Product>> FilterByCategoryAsync(string category) => _repository.FilterByCategoryAsync(category);
        public Task<List<Product>> SearchAsync(string term) => _repository.SearchAsync(term);
        public Task<List<Product>> FilterByPriceRangeAsync(decimal min, decimal max) => _repository.FilterByPriceRangeAsync(min, max);
    }
}
