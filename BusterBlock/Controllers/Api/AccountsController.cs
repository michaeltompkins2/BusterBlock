using BusterBlock.DTOs;
using BusterBlock.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BusterBlock.Controllers.Api
{
    public class AccountsController : BaseApiController
    {

        [HttpGet]
        public IEnumerable<AccountDTO> AccountsByCustomer(int id)
        {
            return _context.Accounts.Where(a => a.CustomerId == id).ToList().Select(AutoMapper.Mapper.Map<Account, AccountDTO>);
        }

    }
}