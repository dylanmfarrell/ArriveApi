namespace ArriveApi.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public string? WarehouseCode { get; set; }
    }
}
