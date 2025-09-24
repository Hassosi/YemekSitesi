using Microsoft.EntityFrameworkCore;
using YemekSitesi.Areas.Admin.Models;
using YemekSitesi.Models;

namespace YemekSitesi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Slider> Sliders { get; set; }
    }
}
