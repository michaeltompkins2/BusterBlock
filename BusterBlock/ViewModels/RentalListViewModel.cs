using BusterBlock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusterBlock.ViewModels
{
    public class RentalListViewModel
    {

        public IEnumerable<Rental> Rentals;

        public RentalListViewModel(IEnumerable<Rental> rentals)
        {
            Rentals = rentals;
        }

    }
}