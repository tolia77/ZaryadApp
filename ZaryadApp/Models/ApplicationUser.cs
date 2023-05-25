using Microsoft.AspNetCore.Identity;

namespace ZaryadApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual Review Review { get; set; }
    }
}
