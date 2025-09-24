using System.ComponentModel.DataAnnotations;

namespace YemekSitesi.Areas.Admin.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EmailAddress]
        public string? UserEmail { get; set; }
        [Required]
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }

    }
}
