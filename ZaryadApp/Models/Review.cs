using System.ComponentModel.DataAnnotations;

namespace ZaryadApp.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заповніть поле")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Заповніть поле")]
        public string City { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "Заповніть поле")]
        public string UserName { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Review()
        {
            
        }
    }
}
