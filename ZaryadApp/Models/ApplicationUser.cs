using Microsoft.AspNetCore.Identity;

namespace ZaryadApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Review Review { get; set; }
        public ApplicationUser()
        {

        }
    }
}
