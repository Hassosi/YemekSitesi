using Microsoft.AspNetCore.Mvc;

namespace YemekSitesi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
