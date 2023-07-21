namespace ArriveApi.Entities
{
    public class Warehouse
    {
        public Warehouse()
        {
        }

        public Warehouse(Guid id, string code)
        {
            Id = id;
            Code = code;
        }

        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
    }
}
