using Ecommerce.Utilities.CommonAttributes;
using ProductServices.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProductServices.Models
{
    public record CategoryModel : CommonProperties
    {
        public CategoryModel()
        {
            Products = new List<Product>();
        }

        [Key]
        public int CategoryId { get; set; }

        public required string CategoryName { get; set; } = string.Empty;

        public virtual ICollection<Product> Products { get; set; }
    }
}
