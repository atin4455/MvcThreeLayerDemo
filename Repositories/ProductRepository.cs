using MvcThreeLayerDemo.Models.Dtos;

namespace MvcThreeLayerDemo.Repositories
{
    // Data Access Layer: 這裡模擬從 DB 查詢資料
    public class ProductRepository : IProductRepository
    {
        public List<ProductDto> GetAllProducts()
        {
            // 真正接 DB 時，這裡會是 SQL/EF 查詢結果
            return
            [
                new ProductDto { Id = 1, Name = "鍵盤", Price = 990 },
                new ProductDto { Id = 2, Name = "滑鼠", Price = 550 },
                new ProductDto { Id = 3, Name = "螢幕", Price = 4590 }
            ];
        }
    }
}
