using System;
using System.ComponentModel.DataAnnotations;

namespace BusterBlock.DTOs
{
    public class MovieDTO
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int StockCount { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreDTO Genre { get; set; }

    }
}