using System.Collections.Generic;
using System.Threading.Tasks;
using ProductServices.Models.Entities;

namespace ProductServices.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<bool> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> RemoveProductAsync(Product product);
    }
}
