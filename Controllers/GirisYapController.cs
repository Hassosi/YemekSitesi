using Microsoft.AspNetCore.Mvc;
using YemekSitesi.Data;
using YemekSitesi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace YemekSitesi.Controllers
{
    public class GirisYapController : Controller
    {
        private readonly AppDbContext _context;

        public GirisYapController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GirisYap(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                // Giriş işlemlerini burada yapın
                var user = _context.Users.FirstOrDefault(u => u.Username == loginViewModel.Username && u.Password == loginViewModel.Password);
                if (user != null)
                {

                    var haklar = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User") // Kullanıcının rolünü ekleyin
                    };
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login");

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) // Oturum süresi
                    };

                    HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(kullaniciKimligi), authProperties);

                    // Giriş başarılı
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
            }

            return View(loginViewModel);
        }

        
    }
}
