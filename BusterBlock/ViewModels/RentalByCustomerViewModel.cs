using BusterBlock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusterBlock.ViewModels
{
    public class RentalByCustomerViewModel
    {

        public Customer Customer { get; set; }

        public bool Historical { get; set; }

    }
}