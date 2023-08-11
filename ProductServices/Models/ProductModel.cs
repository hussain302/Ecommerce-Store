using ProductServices.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ecommerce.Utilities.CommonAttributes;

namespace ProductServices.Models
{
    public record ProductModel : CommonProperties
    {

        [Key]
        public int ProductId { get; set; } //PK
        public required string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public required decimal Price { get; set; }


        [ForeignKey("ImageId")]
        public required int ImageId { get; set; }//FK
        public virtual required ProductImage Image { get; set; }

        [ForeignKey("CategoryId")]
        public required int CategoryId { get; set; } //FK
        public virtual required Category Category { get; set; }
    }
}
