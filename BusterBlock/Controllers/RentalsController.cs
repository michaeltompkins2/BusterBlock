using BusterBlock.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BusterBlock.Controllers
{
    public class RentalsController : BaseController
    {

        #region Actions

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Rentals()
        {
            RentalListViewModel rentalListViewModel = new RentalListViewModel
            (
                _context.Rentals.Include(r => r.Movie).Include(r => r.Customer).Where(r => r.DateReturned == null)
            );

            return View(rentalListViewModel);
        }

        public ActionResult Return(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(r => r.Id == id);

            if (rental == null)
            {
                return HttpNotFound();
            }

            rental.DateReturned = DateTime.Now;

            _context.SaveChanges();

            return View("Rentals", new RentalListViewModel
            (
                _context.Rentals.Include(r => r.Movie).Include(r => r.Customer).Where(r => r.DateReturned == null)
            ));
        }

        #endregion

    }
}