using BusterBlock.Models;
using System.Collections.Generic;

namespace BusterBlock.ViewModels
{
    public class MovieFormViewModel
    {

        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

    }
}