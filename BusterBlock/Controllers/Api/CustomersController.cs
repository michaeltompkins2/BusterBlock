using AutoMapper;
using BusterBlock.DTOs;
using BusterBlock.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace BusterBlock.Controllers.Api
{
    public class CustomersController : BaseApiController
    {

        #region Actions

        #region GetCustomers

        // GET /api/customers
        public IEnumerable<CustomerDTO> GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
            {
               customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            return customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        #endregion

        #region GetCustomer

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
            }
        }

        #endregion

        #region CreateCustomer

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }

        #endregion

        #region UpdateCustomer

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Customer existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (existingCustomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDTO, existingCustomer);

            _context.SaveChanges();
        }

        #endregion

        #region DeleteCustomer

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (existingCustomer == null)
            {
                return NotFound();
            }
            else if (_context.Rentals.SingleOrDefault(r => r.Customer.Id == id && r.DateReturned == null) != null)
            {
                return BadRequest("The Customer cannot be deleted because they have a rental(s) that has not yet been returned.");
            }

            _context.Customers.Remove(existingCustomer);

            _context.SaveChanges();

            return Ok();
        }

        #endregion

        #endregion

    }
}