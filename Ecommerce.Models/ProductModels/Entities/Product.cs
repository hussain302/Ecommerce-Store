using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductServices.Models.Entities
{
    public record Product 
    {
        [Key]
        public int ProductId { get; set; } //PK
        public required string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public required decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        [ForeignKey("CategoryId")]
        public required int CategoryId { get; set; } //FK
        public virtual required Category Category { get; set; } 

    }
}
