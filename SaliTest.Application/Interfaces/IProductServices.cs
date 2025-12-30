using SaliTest.Application.DTOs;

namespace SaliTest.Application.Interfaces
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(long productId);
    }
}