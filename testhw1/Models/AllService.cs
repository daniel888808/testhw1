using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testhw1.Models
{
    public class AllService
    {
        public List<Models.SalesOrder> GetOrdersByCondition(Models.SalesOrder arg)
        {
            List<Models.SalesOrder> result = new List<SalesOrder>();
            result.Add(new SalesOrder() { OrderID = 1, CustomerID = 3, EmployeeID = 1, OrderDate = new DateTime(2011, 6, 10), RequiredDate = new DateTime(2011, 6, 10), ShippedDate = new DateTime(2011, 6, 10), ShipperID = 02555, Freight = 500, ShipCity = "hsinchu", ShipRegion="north", ShipCountry="china",ShipAddress="china road 13 floor",ShipostalCode="55156"});
            result.Add(new SalesOrder() { OrderID = 2, CustomerID = 3, EmployeeID = 1, OrderDate = new DateTime(2001, 6, 10), RequiredDate = new DateTime(2012, 5, 20), ShippedDate = new DateTime(2011, 6, 10), ShipperID = 02555, Freight = 500, ShipCity = "taipei", ShipRegion = "north", ShipCountry = "china", ShipAddress = "nanjing east road 13 floor", ShipostalCode = "55152" });
            return result;
        }
    }
}