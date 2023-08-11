
using Ecommerce.Utilities.CommonAttributes;
using System.ComponentModel.DataAnnotations;

namespace ProductServices.Models.Entities
{
    public record ProductImage : CommonProperties
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
