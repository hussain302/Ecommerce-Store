
using AutoMapper;
using ProductServices.Models.DTOs;
using ProductServices.Models.Entities;

namespace Ecommerce.MapperConfig
{
    public class ProductMapperConfig
    {
        public static MapperConfiguration RegisterProductMaps()
        {
            try
            {
                var mapperConfig = new MapperConfiguration(configure: config =>
                {
                    config.CreateMap<Product,     ProductDTO>();
                    config.CreateMap<ProductDTO,  Product>();
                    config.CreateMap<Category,    CategoryDTO>();
                    config.CreateMap<CategoryDTO, Category>();
                });

                return mapperConfig;
            }
            catch (Exception)
            {
                throw;
            }
            finally { }
        }
    }
}