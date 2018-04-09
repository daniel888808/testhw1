using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testhw1.Models
{
    public class SalesOrder
    {
        public Int32 OrderID { get; set; }

        public Int32 CustomerID { get; set; }

        public Int32 EmployeeID { get; set; }

        public Nullable<DateTime> OrderDate { get; set; }

        public Nullable<DateTime> RequiredDate { get; set; }

        public Nullable<DateTime> ShippedDate { get; set; }

        public Int32 ShipperID { get; set; }

        public Nullable<Decimal> Freight { get; set; }

        public String ShipAddress { get; set; }

        public String ShipCity { get; set; }

        public String ShipRegion { get; set; }

        public String ShipostalCode { get; set; }

        public String ShipCountry { get; set; }
}


}