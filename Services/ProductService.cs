using MvcThreeLayerDemo.Models.ViewModels;
using MvcThreeLayerDemo.Repositories;

namespace MvcThreeLayerDemo.Services
{
    // Business Layer: 做資料轉換與規則整理
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductVm> GetProductVms()
        {
            var dtos = _productRepository.GetAllProducts();

            return dtos.Select(dto => new ProductVm
            {
                DisplayName = $"{dto.Id}. {dto.Name}",
                DisplayPrice = $"NT$ {dto.Price:N0}"
            }).ToList();
        }
    }
}
