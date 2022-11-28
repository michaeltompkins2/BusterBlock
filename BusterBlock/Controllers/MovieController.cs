using BusterBlock.Models;
using BusterBlock.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BusterBlock.Controllers
{
    public class MovieController : Controller
    {

        #region Fields

        private ApplicationDbContext _context;

        #endregion

        #region Actions

        private MovieListViewModel movieListViewModel() => new MovieListViewModel(_context);

        public ActionResult Movies() => User.IsInRole("CanManageMovies") ? View(movieListViewModel()) : View("ReadOnlyMovies", movieListViewModel());

        public ActionResult MovieDesc(int Id)
        {
            Movie movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);

            if (movie == null)
            {
                throw new Exception("Movie does not exist.");
            }

            return View(movie);
        }

        [Authorize(Roles = UserRoles.CanManageMovies)]
        public ActionResult NewMovie() => View("MoviesForm", new MovieFormViewModel() { Genres = _context.Genres.ToList() });

        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound("This movie does not exist.");
            }

            return View
            (
                "MoviesForm", 
                new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                }
            );
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            Movie movie = viewModel.Movie;

            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();

                return View("MoviesForm", viewModel);
            }

            if (movie.Id != 0)
            {
                var existingMovie = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                // AutoMapper.Mapper.Map(movie, existingMovie);

                existingMovie.GenreId = movie.GenreId;
                existingMovie.Name = movie.Name;
                existingMovie.DateAdded = movie.DateAdded;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.StockCount = movie.StockCount;
            }
            else
            {
                _context.Movies.Add(movie);
            }

            _ = _context.SaveChanges();

            return View("Movies", movieListViewModel());
        }

        #endregion

        #region Overrides

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

            base.Dispose(disposing);
        }

        #endregion

        #region Constructor

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

    }
}