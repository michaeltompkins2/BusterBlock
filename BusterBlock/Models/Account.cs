using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusterBlock.Models
{
    public class Account
    {

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(10)]
        public string AccountCD { get; set; }

        public bool IsCashAccount { get; set; }

        public bool Payable { get; set; }

        public bool Receivable { get; set; }

    }
}