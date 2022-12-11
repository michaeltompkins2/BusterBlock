using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusterBlock.Models
{
    public class Account
    {

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(10)]
        [Display(Name = "Account Name")]
        public string AccountCD { get; set; }

        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }

        [Display(Name = "Cash Account")]
        public bool IsCashAccount { get; set; }

        [CreditCard]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        public bool Payable { get; set; }

        public bool Receivable { get; set; }

    }
}