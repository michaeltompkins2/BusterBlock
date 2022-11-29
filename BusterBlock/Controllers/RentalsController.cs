using BusterBlock.Models;
using BusterBlock.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System;

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
            RentalListViewModel rentalListViewModel = new RentalListViewModel(_context.Rentals.Include(r => r.Movie).Include(r => r.Customer));

            return View(rentalListViewModel);
        }

        public ActionResult Return()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}