namespace MvcThreeLayerDemo.Models.Dtos
{
    // DTO: 只負責在不同層之間搬運資料
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
