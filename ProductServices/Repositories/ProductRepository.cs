using Microsoft.EntityFrameworkCore;
using ProductServices.Data;
using ProductServices.Models.Entities;

namespace ProductServices.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ILogger<ProductRepository> _logger;
        private readonly ApplicationDbContext _db;

        public ProductRepository(ILogger<ProductRepository> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null)
            {
                throw new ArgumentNullException($"Product with ID {id} not found");
            }
            return product;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                var find = await _db.Products.Where(x => x.ProductName == product.ProductName).FirstOrDefaultAsync();
                if (find != null) throw new Exception($"Product already exists");
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding product");
                throw;
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                var find = await _db.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();
                if (find == null) throw new Exception($"Product doesn't exists against id:{product.ProductId}");
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product");
                throw;
            }
        }

        public async Task<bool> RemoveProductAsync(Product product)
        {
            try
            {
                var find = await _db.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();
                if (find == null) throw new Exception($"Product doesn't exists against id:{product.ProductId}");
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing product");
                throw;
            }
        }
    }
}