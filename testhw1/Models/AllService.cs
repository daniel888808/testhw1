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
            result.Add(new SalesOrder() { OrderID = 1, CustomerID = 1, EmployeeID = 1, OrderDate = new DateTime(2011, 6, 10), RequiredDate = new DateTime(2011, 6, 10), ShippedDate = new DateTime(2011, 6, 10), ShipperID = 02555, Freight = 500, ShipCity = "hsinchu", ShipRegion="north", ShipCountry="china",ShipAddress="china road 13 floor",ShipostalCode="55156"});
            result.Add(new SalesOrder() { OrderID = 2, CustomerID = 2, EmployeeID = 2, OrderDate = new DateTime(2001, 6, 10), RequiredDate = new DateTime(2012, 5, 20), ShippedDate = new DateTime(2011, 6, 10), ShipperID = 02555, Freight = 500, ShipCity = "taipei", ShipRegion = "north", ShipCountry = "china", ShipAddress = "nanjing east road 13 floor", ShipostalCode = "55152" });
            return result;
        }
        public List<Models.HrEmployees> GetEmployeesByCondition(Models.HrEmployees arg)
        {
            List<Models.HrEmployees> result = new List<HrEmployees>();
            result.Add(new HrEmployees() { EmployeeID = 1, LastName="Peng", FirstName="Daniel" });
            result.Add(new HrEmployees() { EmployeeID = 2, LastName = "Scola", FirstName = "Luis" });
            return result;
        }
        public List<Models.SalesCustomers> GetCustomersByCondition(Models.SalesCustomers arg)
        {
            List<Models.SalesCustomers> result = new List<SalesCustomers>();
            result.Add(new SalesCustomers() { CustomerID = 1, CompanyName="acom", Address="taipei taipeiroad321", ContactName="Sam"});
            result.Add(new SalesCustomers() { CustomerID = 2, CompanyName = "bcom", Address = "kaoshuing kaoshuing road1231", ContactName = "Peter" });
            return result;
        }
        public List<Models.SalesShippers> GetShiperByCondition(Models.SalesShippers arg)
        {
            List<Models.SalesShippers> result = new List<SalesShippers>();
            result.Add(new SalesShippers() { ShipperID=1, CompanyName="abccom", Phone="5522111"});
            result.Add(new SalesShippers() { ShipperID = 2, CompanyName = "defcom", Phone = "5155222" });
            return result;
        }
    }
}