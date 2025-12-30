using SaliTest.Domain.Entities;

namespace SaliTest.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>?> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(long id);
    }
}