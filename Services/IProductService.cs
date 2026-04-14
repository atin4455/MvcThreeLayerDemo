using MvcThreeLayerDemo.Models.ViewModels;

namespace MvcThreeLayerDemo.Services
{
    public interface IProductService
    {
        List<ProductVm> GetProductVms();
    }
}
