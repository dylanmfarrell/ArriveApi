using System.ComponentModel.DataAnnotations;

namespace ArriveApi.Entities
{
    public class Product
    {
        public Product() { }
        public Product(Guid id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        //product would likely be assigned to a warehouse. Could be nullable in certain senarios where there is virtual inventory (service plans, digital gift cards, etc)
        //public Warehouse? Warehouse { get; set; }
        //public Guid? WarehouseId { get; set; }
    }
}
