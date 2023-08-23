using ProductServices.Models.DTOs;
using ProductServices.Models.Entities;

namespace Ecommerce.WebUI.DAL.IRepositories
{
    public interface ICategoryRepository
    {

        Task<IAsyncEnumerable<Category>> GetAll();
        Task<Category> Get(int id);
        Task<bool> Add(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(int id);  

    }
}
