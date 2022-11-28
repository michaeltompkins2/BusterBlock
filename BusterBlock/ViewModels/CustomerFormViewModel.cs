using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusterBlock.Models
{
    public class CustomerFormViewModel
    {

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }

        public CustomerFormViewModel(Customer customer, IEnumerable<MembershipType> membershipTypes)
        {
            Customer = customer;
            MembershipTypes = membershipTypes;
        }

    }
}