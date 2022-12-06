using BusterBlock.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BusterBlock.Controllers
{
    public class CustomerController : BaseController
    {

        #region Actions

        #region Customers

        public ActionResult Customers() => View();

        #endregion

        #region Details

        [Route("Customer/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            Customer customer = _context.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                throw new Exception("Customer Does not exist!!");
            }

            return View(customer);
        }

        #endregion

        #region NewCustomer

        public ActionResult NewCustomer() => View("CustomerForm", new CustomerFormViewModel(new Customer(), _context.MembershipTypes.ToList()));

        #endregion

        #region Save

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {
            Customer customer = viewModel.Customer;

            if (!ModelState.IsValid)
            {
                return View("CustomerForm", new CustomerFormViewModel(customer, _context.MembershipTypes.ToList()));
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else 
            {
                var existingCustomer = _context.Customers.Single(c => c.Id == customer.Id);

                existingCustomer.Name = customer.Name;
                existingCustomer.BirthDate = customer.BirthDate;
                existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                existingCustomer.MembershipTypeId = customer.MembershipTypeId;                
            }

            _ =_context.SaveChanges();

            return RedirectToAction("Customers", "Customer");
        }

        #endregion

        #region Edit

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View("CustomerForm", new CustomerFormViewModel(customer, _context.MembershipTypes.ToList()));
        }

        #endregion

        #endregion


    }
}