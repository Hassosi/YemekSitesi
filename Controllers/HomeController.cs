using Microsoft.AspNetCore.Mvc;
using YemekSitesi.Data;
using YemekSitesi.Models;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int? categoryId)
    {

        var viewModel = new HomeViewModel
        {
            Sliders = _context.Sliders.ToList(),
            Products = _context.Products.ToList()
        };

        return View(viewModel);


        //var products = _context.Products.AsQueryable();

        //if (categoryId.HasValue)
        //{
        //    products = products.Where(p => p.CategoryId == categoryId.Value);
        //}

        //return View(products.ToList());
    }
}
