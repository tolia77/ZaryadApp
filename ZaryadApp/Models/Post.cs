using System.ComponentModel.DataAnnotations;
namespace ZaryadApp.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заповніть поле")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Заповніть поле")]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public Post()
        {

        }
    }
}
