namespace YemekSitesi.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } // Resmin yolu
        public string? Title { get; set; }   // Opsiyonel: Başlık
        public string? Description { get; set; } // Opsiyonel: Açıklama
    }
}
