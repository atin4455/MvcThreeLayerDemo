using MvcThreeLayerDemo.Models.Dtos;

namespace MvcThreeLayerDemo.Repositories
{
    public interface IProductRepository
    {
        List<ProductDto> GetAllProducts();
    }
}
