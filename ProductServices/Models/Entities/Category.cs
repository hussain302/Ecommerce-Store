using Ecommerce.Utilities.CommonAttributes;
using System.ComponentModel.DataAnnotations;

namespace ProductServices.Models.Entities
{
    public record Category : CommonProperties
    {

        public Category()
        {
             Products = new List<Product>();
        }

        [Key]
        public int CategoryId { get; set; }
     
        public required string CategoryName { get; set; } = string.Empty;

        public virtual ICollection<Product> Products { get; set; }

    }
}
