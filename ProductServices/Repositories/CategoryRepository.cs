
using Microsoft.EntityFrameworkCore;
using ProductServices.Data;
using ProductServices.Models.Entities;

namespace ProductServices.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ILogger<CategoryRepository> _logger;
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ILogger<CategoryRepository> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            try
            {
                var find = await _db.Categories.Where(x => x.CategoryName == category.CategoryName).FirstOrDefaultAsync();
                if (find != null) throw new Exception("Category already exists");
                _db.Categories.Add(category);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding category");
                throw; 
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            try
            {
                return await _db.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting categories");
                throw; 
            }
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (category == null)
            {
                throw new ArgumentNullException($"Category with ID {id} not found");
            }
            return category;
        }


        public async Task<bool> RemoveCategoryAsync(Category category)
        {
            try
            {
                var find = await _db.Categories.Where(x => x.CategoryId == category.CategoryId).FirstOrDefaultAsync();
                if (find == null) throw new Exception($"Category doesn't exists against id:{category.CategoryId}");
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing category");
                throw;
            }
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            try
            {
                var find = await _db.Categories.Where(x => x.CategoryId == category.CategoryId).FirstOrDefaultAsync();
                if (find == null) throw new Exception($"Category doesn't exists against id:{category.CategoryId}");
                _db.Categories.Update(category);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating category");
                throw;
            }
        }
    }
}
