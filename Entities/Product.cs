namespace ArriveApi.Entities
{
    public class Product
    {
        public Product() { }
        public Product(Guid id, string name, int quantity, Guid? warehouseId)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            //WarehouseId = warehouseId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        //public Warehouse? Warehouse { get; set; }
        //public Guid? WarehouseId { get; set; }
    }
}
