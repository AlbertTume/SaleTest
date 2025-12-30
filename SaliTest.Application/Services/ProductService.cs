using System.Xml.Schema;
using AutoMapper;
using SaliTest.Application.DTOs;
using SaliTest.Application.Interfaces;

namespace SaliTest.Application.Services
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productDtos;
        }

        public async Task<ProductDto?> GetProductByIdAsync(long productId)
        {
            if (productId <= 0)
            {
                return null!;
            }

            var product =  await _productRepository.GetProductByIdAsync(productId);
            if (product == null)
            {
                return null!;
            } 
            
            var productDto = _mapper.Map<ProductDto>(product);
            
            return productDto; 
        }
    }
}