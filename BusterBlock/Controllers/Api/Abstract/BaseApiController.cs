using BusterBlock.Models;
using System.Web.Http;

namespace BusterBlock.Controllers.Api
{
    public abstract class BaseApiController : ApiController
    {

        #region Fields

        protected ApplicationDbContext _context;

        #endregion

        #region Constructor

        public BaseApiController()
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