using System.Collections.Generic;
using System.Web.Mvc;

namespace BusterBlock
{
    public static class ARDocStrings
    {

        #region Status

        public static class Status
        {
            public const string Hold = "H";
            public const string Pending = "P";
            public const string Completed = "C";

            public static List<SelectListItem> StatusList() => new List<SelectListItem>()
            {
                new SelectListItem {Text = "Hold", Value = Hold },
                new SelectListItem {Text = "Pending", Value = Pending },
                new SelectListItem {Text = "Completed", Value = Completed }
            };
        }

        #endregion

        #region DocType

        public static class DocType
        {
            public const string CashSale = "C";
            public const string Invoice = "I";

            public static List<SelectListItem> DocTypeList() => new List<SelectListItem>()
            {
                new SelectListItem { Text = "Cash Sale", Value = CashSale },
                new SelectListItem { Text = "Invoice", Value = Invoice }
            };
        }

        #endregion

    }
}