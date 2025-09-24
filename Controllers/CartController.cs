using Microsoft.AspNetCore.Mvc;
using YemekSitesi.Data;
using YemekSitesi.Extensions;
using YemekSitesi.Models;

namespace YemekSitesi.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        public CartController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sepet = HttpContext.Session.Get<List<Product>>("Sepet") ?? new List<Product>();
            return View(sepet);
        }
        [HttpPost]
        public IActionResult SepeteEkle(int id)
        {
            // Id'ye göre ürün bul
            var urun = _context.Products.FirstOrDefault(p => p.Id == id);
            if (urun == null) return NotFound();

            // Session'dan sepeti çek
            var sepet = HttpContext.Session.Get<List<Product>>("Sepet") ?? new List<Product>();

            // Listeye yeni ürünü ekle
            sepet.Add(urun);

            // Tekrar session'a yaz
            HttpContext.Session.SetJson("Sepet", sepet);

            return RedirectToAction("Index"); // ürün listesine geri dön
        }
        public IActionResult SepettenCikar(int id)
        {
            // Session'dan sepeti çek
            var sepet = HttpContext.Session.Get<List<Product>>("Sepet") ?? new List<Product>();
            // Id'ye göre ürünü bul ve listeden çıkar
            var urun = sepet.FirstOrDefault(p => p.Id == id);
            if (urun != null)
            {
                sepet.Remove(urun);
                // Güncellenmiş listeyi tekrar session'a yaz
                HttpContext.Session.SetJson("Sepet", sepet);
            }
            return RedirectToAction("Index"); // ürün listesine geri dön
        }
        public IActionResult SepetiBosalt()
        {
            // Sepeti boşalt
            HttpContext.Session.Remove("Sepet");
            return RedirectToAction("Index"); // ürün listesine geri dön
        }

    }
}
