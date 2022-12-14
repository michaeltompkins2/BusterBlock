using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusterBlock.DTOs
{
    public class AccountDTO
    {

        public int Id { get; set; }

        public string AccountCD { get; set; }

        public bool IsCashAccount { get; set; }

        public bool Payable { get; set; }

        public bool Receivable { get; set; }

    }
}