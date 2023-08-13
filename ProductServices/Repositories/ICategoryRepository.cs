using ProductServices.Models.Entities;

namespace ProductServices.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<bool> AddCategoryAsync(Category category);
        Task<bool> RemoveCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
    }
}
