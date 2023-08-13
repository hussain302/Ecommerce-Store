using AutoMapper;
using Ecommerce.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using ProductServices.Models.DTOs;
using ProductServices.Models.Entities;
using ProductServices.Repositories;

namespace ProductServices.Controllers
{
    [Route("service/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController ( ICategoryRepository categoryRepository, IMapper mapper, ILogger<CategoriesController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await _categoryRepository.GetCategoriesAsync();
                var mappedCategories = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
                var response = new ApiResponse<IEnumerable<CategoryDTO>>()
                {
                    IsSuccess = true,
                    Data = mappedCategories,
                    Message = "Categories retrieved successfully."
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<CategoryDTO>>()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message
                };
                _logger.LogError(ex, response.Message);
                return Ok(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryAsync(id);
                if (category == null)
                {
                    var response = new ApiResponse<CategoryDTO>()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = $"Category does not exist for category id: {id}"
                    };
                    return Ok(response);
                }

                var mappedCategory = _mapper.Map<CategoryDTO>(category);
                var successResponse = new ApiResponse<CategoryDTO>()
                {
                    IsSuccess = true,
                    Data = mappedCategory,
                    Message = "Category retrieved successfully."
                };
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<CategoryDTO>()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message
                };
                _logger.LogError(ex, response.Message);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var find = await _categoryRepository.GetCategoryAsync(id);
                var success = await _categoryRepository.RemoveCategoryAsync(find);
                var response = new ApiResponse<string>()
                {
                    IsSuccess = success,
                    Data = null,
                    Message = success ? $"Category with ID {id} deleted successfully" : $"Category with ID {id} not found"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message
                };
                _logger.LogError(ex, response.Message);
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDTO);

                var success = await _categoryRepository.AddCategoryAsync(category);
                var response = new ApiResponse<string>()
                {
                    IsSuccess = success,
                    Data = null,
                    Message = success ? $"{categoryDTO.CategoryName} added successfully" : "Failed to add category"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message
                };
                _logger.LogError(ex, response.Message);
                return Ok(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                var existingCategory = await _categoryRepository.GetCategoryAsync(categoryDTO.CategoryId);
                if (existingCategory == null)
                {
                    var notFoundResponse = new ApiResponse<string>()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "Category does not exist"
                    };
                    return Ok(notFoundResponse);
                }

                _mapper.Map(categoryDTO, existingCategory);

                var success = await _categoryRepository.UpdateCategoryAsync(existingCategory);
                var response = new ApiResponse<string>()
                {
                    IsSuccess = success,
                    Data = null,
                    Message = success ? $"{categoryDTO.CategoryName} updated successfully" : "Failed to update category"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = ex.Message
                };
                _logger.LogError(ex, response.Message);
                return Ok(response);
            }
        }
    }
}
