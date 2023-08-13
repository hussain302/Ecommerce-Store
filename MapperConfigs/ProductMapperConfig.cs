using AutoMapper;
using ProductServices.Models.Entities;
using ProductServices.Models.DTOs;

namespace MapperConfigs
{
    public class ProductMapperConfig
    {
        public static MapperConfiguration RegisterCouponMaps()
        {
            try
            {
                var mapperConfig = new MapperConfiguration(configure: config =>
                {
                    config.CreateMap<Product, ProductDTO>();
                    config.CreateMap<ProductDTO, Product>();
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