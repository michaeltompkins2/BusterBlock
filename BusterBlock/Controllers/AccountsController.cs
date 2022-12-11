using BusterBlock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusterBlock.Controllers
{
    public class AccountsController : BaseController
    {
        // GET: Accounts
        public ActionResult CustomerAccounts()
        {
            return View();
        }

        public ActionResult AccountsForm()
        {
            Account account = new Account();

            return View(account);
        }
        public ActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Add(account);

                _context.SaveChanges();
            }

            return View();
        }
    }
}