﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZaryadApp.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Plug { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Voltage { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public Station()
        {
            
        }
    }

}
