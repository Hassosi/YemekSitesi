using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using YemekSitesi.Data;

namespace YemekSitesi.Controllers
{
    public class ProfilController : Controller
    {
        private readonly AppDbContext _context;

        public ProfilController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "GirisYap"); // giriş sayfasına yönlendir
            }

            var username = User.Identity.Name;

            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                return NotFound();

            return View(user);
        }

        public async Task<IActionResult> CikisYapAsync()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index", "Home");
        }
    }
}
