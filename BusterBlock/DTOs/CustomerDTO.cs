using BusterBlock.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusterBlock.DTOs
{
    public class CustomerDTO
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

        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        #endregion

        public MembershipTypeDTO MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }


    }
}