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
            var dtos = _productRepository.GetAllProducts(); //1.從 Repository 取得 DTOs

            return dtos.Select(dto => new ProductVm //2.將 DTOs 轉換成 ViewModels,並從Service層回傳至 Controller(Web層)
            {
                DisplayName = $"{dto.Id}. {dto.Name}",
                DisplayPrice = $"NT$ {dto.Price:N0}"
            }).ToList();
        }
    }
}
