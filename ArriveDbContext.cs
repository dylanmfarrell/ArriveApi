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
            modelBuilder.Entity<Warehouse>().HasData(
               new Warehouse(Guid.NewGuid(), "Warehouse1"),
               new Warehouse(Guid.NewGuid(), "Warehouse2")
           );

            modelBuilder.Entity<Product>().HasData(
               new Product(Guid.NewGuid(), "YETICOOLERBLUE", 10, null),
               new Product(Guid.NewGuid(), "YETICOOLERRED", 20, null),
               new Product(Guid.NewGuid(), "YETICOOLERGREEN", 40, null)
           );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
    }
}
