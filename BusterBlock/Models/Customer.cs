using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusterBlock.Models
{
    public class Customer
    {

        #region Name

        [Required(ErrorMessage = "Please enter the customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        #endregion

        #region Id

        public int Id { get; set; }

        #endregion

        #region IsSubscribedToNewsLetter

        public bool IsSubscribedToNewsletter { get; set; }

        #endregion

        #region BirthDate

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        #endregion

        #region MembershipType

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        #endregion

    }
}