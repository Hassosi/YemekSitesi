namespace YemekSitesi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Img {  get; set; }

        public int CategoryId { get; set; } // FK
        public Category? Category { get; set; } // Navigation property
        public bool IsHome { get; set; } = true;
        public bool IsActive { get; set; } = true;

    }
}


