using BusterBlock.Models;
using System.Collections.Generic;

namespace BusterBlock.ViewModels
{
    public class CustomerListViewModel
    {

        public List<Customer> CustomerList { get; set; }

        public CustomerListViewModel()
        {
            CustomerList = new List<Customer>();
        }

    }
}