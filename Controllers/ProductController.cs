using Microsoft.AspNetCore.Mvc;

namespace YemekSitesi.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
