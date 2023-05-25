using System.ComponentModel.DataAnnotations.Schema;

namespace ZaryadApp.Models
{
    public class Review
    {
        [ForeignKey("ApplicationUser")]
        public string ReviewId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
