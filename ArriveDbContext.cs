using ArriveApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArriveApi
{
    public class ArriveDbContext : DbContext
    {
        public ArriveDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        //This system would likely have warehouses/nodes that have inventory assigned to them
        public DbSet<Warehouse> Warehouse { get; set; }
    }
}
