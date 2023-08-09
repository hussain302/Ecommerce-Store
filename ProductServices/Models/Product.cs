namespace ProductServices.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = new();
    }
}
