using BusterBlock.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusterBlock.DTOs
{
    public class RentalDTO
    {

        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

    }
}