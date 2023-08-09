namespace ProductServices.Models
{
    public class Category
    {

        public Category()
        {
             Products = new List<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public virtual ICollection<Product> Products { get; set; }

    }
}
