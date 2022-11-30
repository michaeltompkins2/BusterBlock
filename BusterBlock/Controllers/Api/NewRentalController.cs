using AutoMapper;
using BusterBlock.DTOs;
using BusterBlock.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace BusterBlock.Controllers.Api
{
    public class NewRentalController : BaseApiController
    {

        #region Actions

        #region Rentals

        [HttpGet]
        public IEnumerable<RentalDTO> Rentals() => _context.Rentals.Include(r => r.Customer).Include(r => r.Movie).ToList().Select(Mapper.Map<Rental, RentalDTO>);

        #endregion

        #region CreateNewRental

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

        #region RentalReturn

        [HttpPut]
        public IHttpActionResult RentalReturn(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(r => r.Id == id);

            if (rental == null)
            {
                return BadRequest("Rental does not exist within the system.");
            }

            rental.DateReturned = DateTime.Now;

            _context.SaveChanges();

            return Ok();
        }

        #endregion

        #endregion

    }
}