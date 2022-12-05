using BusterBlock.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusterBlock.Controllers
{
    public class RentalsController : BaseController
    {

        #region Actions

        #region New

        public ActionResult New()
        {
            return View();
        }

        #endregion

        #region Rentals

        public ActionResult Rentals()
        {
            RentalListViewModel rentalListViewModel = new RentalListViewModel
            (
                _context.Rentals.Include(r => r.Movie).Include(r => r.Customer).Where(r => r.DateReturned == null)
            );

            return View(rentalListViewModel);
        }

        #endregion

        #region Return

        public ActionResult Return(int id)
        {
            returnRental(id);

            _context.SaveChanges();

            return RedirectToAction("Rentals", model());
        }

        #endregion

        #region ReturnAll

        public ActionResult ReturnAll(int id)
        {
            foreach (var rental in _context.Rentals.Where(r => r.Customer.Id == id).ToList())
            {
                returnRental(rental.Id);
            }

            _context.SaveChanges();

            return RedirectToAction("OutstandingRentalsByCustomer", id);
        }

        #endregion

        #region OutstandingRentalsByCustomer

        public ActionResult OutstandingRentalsByCustomer(int id)
        {
            var customer =_context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        #endregion

        #endregion

        #region Methods

        #region returnRental

        private void returnRental(int rentalId)
        {
            var rental = _context.Rentals.Include(r => r.Movie).SingleOrDefault(r => r.Id == rentalId);

            if (rental == null)
            {
                throw new HttpException(404, "Rental is not found within the system.");
            }

            rental.DateReturned = DateTime.Now;

            var movie = _context.Movies.SingleOrDefault(m => m.Id == rental.Movie.Id);

            if (movie == null)
            {
                throw new HttpException(404, "Movie is no longer within the system.");
            }

            movie.AvailableStock += 1;
        }

        #endregion

        #region model

        private RentalListViewModel model() => new RentalListViewModel
        (
            _context.Rentals.Include(r => r.Movie).Include(r => r.Customer).Where(r => r.DateReturned == null)
        );

        #endregion

        #endregion

    }
}