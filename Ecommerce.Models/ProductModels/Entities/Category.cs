using System.ComponentModel.DataAnnotations;

namespace ProductServices.Models.Entities
{
    public record Category
    {

        
        [Key]
        public int CategoryId { get; set; }
     
        public required string CategoryName { get; set; } = string.Empty;


    }
}
