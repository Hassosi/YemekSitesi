namespace YemekSitesi.Models
{
    public class Category
    {
        public int Id { get; set; } // Identity olacak
        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; } // 1 kategoriye çok ürün
    }
}
