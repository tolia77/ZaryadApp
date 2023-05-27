using Microsoft.AspNetCore.Identity;

namespace ZaryadApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Review Review { get; set; }
        public ICollection<Settings> Settings { get; } = new List<Settings>();
        public ApplicationUser()
        {

        }
    }
}
