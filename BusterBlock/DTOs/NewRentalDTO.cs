using System.Collections.Generic;

namespace BusterBlock.DTOs
{
    public class NewRentalDTO
    {

        public int CustomerID { get; set; }

        public List<int> MovieIDs { get; set; }

    }
}