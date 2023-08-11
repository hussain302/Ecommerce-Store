using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductServices.Data;
using ProductServices.Models.Entities;

namespace ProductServices.Controllers
{
    [Route("service/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await _db.Categories.ToListAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _db.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
                if (category == null) return NotFound($"Category does not exists against category id: {id}");
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var find = await _db.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (find == null) return NotFound();
            _db.Categories.Remove(find);
            await _db.SaveChangesAsync();
            return Ok($"{find.CategoryName} Deleted successfully");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            try
            {
                var find = await _db.Categories.FirstOrDefaultAsync(x => x.CategoryName == category.CategoryName);
                if (find == null)
                {
                    await _db.Categories.AddAsync(category);
                    await _db.SaveChangesAsync();
                    return Ok($"{category.CategoryName} added successfully");
                }
                return BadRequest("Category name already exists");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            try
            {
                var find = await _db.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
                if (find == null) return BadRequest("Category does not exists");
                find.CategoryName = category.CategoryName;
                find.ModifiedBy = category.ModifiedBy;
                find.ModifiedOn = category.ModifiedOn;
                _db.Categories.Update(find);
                await _db.SaveChangesAsync();
                return Ok($"{category.CategoryName} updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
