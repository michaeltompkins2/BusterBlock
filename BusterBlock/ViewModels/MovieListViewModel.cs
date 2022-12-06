using BusterBlock.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace BusterBlock.ViewModels
{
    public class MovieListViewModel
    {
        public List<Movie> movies;

        public MovieListViewModel(ApplicationDbContext context)
        {
            movies = context.Movies.Include(m => m.Genre).ToList();
        }

        public MovieListViewModel()
        {
        }
    }
}