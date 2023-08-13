using ProductServices.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProductServices.Models.DTOs
{
    public record CategoryDTO  
    {
      
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; } = string.Empty;

    }
}
