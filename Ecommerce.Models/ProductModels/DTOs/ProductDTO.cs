﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductServices.Models.DTOs
{
    public record ProductDTO 
    {

        [Key]
        public int ProductId { get; set; } //PK
        public required string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public required decimal Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;


        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; } //FK
        public virtual CategoryDTO? Category { get; set; }
    }
}
