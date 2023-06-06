using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZaryadApp.Models
{
    public class Station
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заповніть поле")]
        public string City { get; set; }
        [Required(ErrorMessage = "Заповніть поле")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Заповніть поле")]
        public string Plug { get; set; }
        [Required(ErrorMessage = "Заповніть поле")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Voltage { get; set; }
        [Required(ErrorMessage = "Заповніть поле")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public Station()
        {
            
        }
    }

}
