using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusterBlock.Models
{
    public class ARDocument
    {

        [Key, Column(Order = 0)]
        [StringLength(1)]
        public string DocType { get; set; }

        [Key, Column(Order = 1)]
        [StringLength(10)]
        public string RefNbr { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        public DateTime DateEntered { get; set; }

        public Account Account { get; set; }

        [Required]
        public int AccountId { get; set; }

        public decimal Amount { get; set; }

    }
}