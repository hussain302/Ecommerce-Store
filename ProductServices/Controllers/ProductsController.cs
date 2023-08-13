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
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository, IMapper mapper, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productRepository.GetProductsAsync();
                var mappedProducts = _mapper.Map<IEnumerable<ProductDTO>>(products);
                var response = new ApiResponse<IEnumerable<ProductDTO>>()
                {
                    IsSuccess = true,
                    Data = mappedProducts,
                    Message = "Products retrieved successfully."
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<IEnumerable<ProductDTO>>()
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
                var product = await _productRepository.GetProductAsync(id);
                if (product == null)
                {
                    var response = new ApiResponse<ProductDTO>()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = $"Product does not exist for ID: {id}"
                    };
                    return Ok(response);
                }

                var mappedProduct = _mapper.Map<ProductDTO>(product);
                var successResponse = new ApiResponse<ProductDTO>()
                {
                    IsSuccess = true,
                    Data = mappedProduct,
                    Message = "Product retrieved successfully."
                };
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<ProductDTO>()
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
                var find = await _productRepository.GetProductAsync(id);
                var success = await _productRepository.RemoveProductAsync(find);
                var response = new ApiResponse<string>()
                {
                    IsSuccess = success,
                    Data = null,
                    Message = success ? $"Product with ID {id} deleted successfully" : $"Product with ID {id} not found"
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
        public async Task<IActionResult> Post([FromBody] ProductDTO productDTO)
        {
            try
            {
                var product = _mapper.Map<Product>(productDTO);

                var success = await _productRepository.AddProductAsync(product);
                var response = new ApiResponse<string>()
                {
                    IsSuccess = success,
                    Data = null,
                    Message = success ? $"{productDTO.ProductName} added successfully" : "Failed to add product"
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
        public async Task<IActionResult> Put([FromBody] ProductDTO productDTO)
        {
            try
            {
                var existingProduct = await _productRepository.GetProductAsync(productDTO.ProductId);
                if (existingProduct == null)
                {
                    var notFoundResponse = new ApiResponse<string>()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "Product does not exist"
                    };
                    return Ok(notFoundResponse);
                }

                _mapper.Map(productDTO, existingProduct);

                var success = await _productRepository.UpdateProductAsync(existingProduct);
                var response = new ApiResponse<string>()
                {
                    IsSuccess = success,
                    Data = null,
                    Message = success ? $"{productDTO.ProductName} updated successfully" : "Failed to update product"
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
