using BusterBlock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusterBlock
{
    public abstract class BaseController : Controller
    {

        #region Fields

        protected ApplicationDbContext _context;

        #endregion

        #region Constructor

        public BaseController()
        {
            _context = new ApplicationDbContext();
        }

        #endregion

        #region Overrides

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

            base.Dispose(disposing);
        }

        #endregion

    }
}