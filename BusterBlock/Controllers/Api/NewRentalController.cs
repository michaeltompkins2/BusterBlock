using BusterBlock.DTOs;
using BusterBlock.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace BusterBlock.Controllers.Api
{
    public class NewRentalController : ApiController
    {

        #region Fields

        private ApplicationDbContext _context;

        #endregion

        #region Actions

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDTO newRentalDTO)
        {
            if (newRentalDTO.MovieIDs.Count == 0)
            {
                return BadRequest("No Movie's have been provided in the request.");
            }

            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == newRentalDTO.CustomerID);

            if (customer == null)
            {
                return BadRequest("CustomerID is not valid.");
            }

            foreach (Movie movie in _context.Movies.Where(m => newRentalDTO.MovieIDs.Contains(m.Id)))
            {
                if (movie.AvailableStock == 0)
                {
                    return BadRequest("Movie is not available");
                }

                movie.AvailableStock--;

                _context.Rentals.Add(new Rental() { Customer = customer, Movie = movie, DateRented = DateTime.Now });
            }

            _context.SaveChanges();

            return Ok();
        }

        #endregion

        #region Constructor

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

    }
}