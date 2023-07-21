using ArriveApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArriveApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ArriveDbContext _context;

        public ProductRepository(ILogger<ProductRepository> logger, ArriveDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetList()
        {
            return await _context.Products
                //.Include(x=>x.Warehouse)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product?> GetById(Guid productId)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<Product?> Create(Product product)
        {
            _context.Products.Add(product);

            int recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0 ? product : null;
        }

        public async Task<bool> Delete(Guid productId)
        {
            Product? productToDelete = _context.Products.FirstOrDefault(x => x.Id == productId);

            if (productToDelete == null)
                return false;

            _context.Products.Remove(productToDelete);

            int recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0;
        }

        public async Task<Product?> UpdateQuantity(Guid productId, int quantity)
        {
            Product? productToUpdate = _context.Products.FirstOrDefault(x => x.Id == productId);

            if (productToUpdate == null)
                return null;

            productToUpdate.Quantity = quantity;

            int recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected > 0 ? productToUpdate : null;
        }

    }

    public interface IProductRepository
    {
        Task<Product?> Create(Product product);
        Task<bool> Delete(Guid productId);
        Task<Product?> GetById(Guid productId);
        Task<List<Product>> GetList();
        Task<Product?> UpdateQuantity(Guid productId, int quantity);
    }
}
