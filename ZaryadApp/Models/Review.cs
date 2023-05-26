using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZaryadApp.Models
{
    public class Review
    {
        [ForeignKey("ApplicationUser")]
        [Required]
        public string ReviewId { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public Review()
        {
            
        }
    }
}
