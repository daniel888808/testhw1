using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace testhw1.Controllers
{
    public class OrderController : Controller
    {
        // GET: index
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        public ActionResult SearchOrder()
        {
            Models.AllService allService = new Models.AllService();
            var OrderResult = allService.GetOrdersByCondition(new Models.SalesOrder());
            var EmployeeResult = allService.GetEmployeesByCondition(new Models.HrEmployees() {});
            var CustomersResult = allService.GetCustomersByCondition(new Models.SalesCustomers());
            var ShiperResult = allService.GetShiperByCondition(new Models.SalesShippers());
            ///員工的select
            List<SelectListItem> EmpItems = new List<SelectListItem>();
            foreach (var category in EmployeeResult)
            {
                EmpItems.Add(new SelectListItem()
                {
                    Text = category.FirstName + category.LastName,
                    Value = category.EmployeeID.ToString()
                }
                    );
            }
            ///出貨公司Select
            List<SelectListItem> ShipperItems = new List<SelectListItem>();
            foreach (var category in ShiperResult)
            {
                ShipperItems.Add(new SelectListItem()
                {
                    Text = category.CompanyName,
                    Value = category.ShipperID.ToString()
                }
                    );
            }

            ViewBag.SelectEmployee = EmpItems;
            ViewBag.SelectCompony =ShipperItems;
            return View();
        }

        [HttpPost()]
        public ActionResult SearchOrderResult(FormCollection post ,Models.SalesOrder arg)
        {
            Models.AllService allService = new Models.AllService();
            
            string OrderID = post["OrderID"];
            string ContactName = post["ContactName"];
            string SelectEmployee = post["SelectEmployee"];
            string SelectCompony = post["SelectCompony"];
            string OderDate = post["OderDate"];
            string ShipperDate = post["ShipperDate"];
            string RequiredDate = post["RequiredDate"];
            var OrderResult = allService.GetOrdersByCondition(new Models.SalesOrder());
            var EmployeeResult = allService.GetEmployeesByCondition(new Models.HrEmployees() {});
            var CustomersResult = allService.GetCustomersByCondition(new Models.SalesCustomers());
            var ShiperResult = allService.GetShiperByCondition(new Models.SalesShippers());
            try
            {
                int OrderIDint = Int32.Parse(OrderID);
                List<Models.SalesOrder> test = OrderResult.Where(m => OrderIDint.Equals(m.OrderID)).ToList();
                ViewBag.Result = test;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            ///string Result="";
            
            ///foreach (var category in test)
            ///{
               /// Result=category.OrderID,category.CustomerID,category.EmployeeID, category.ShipperID, category.OrderDate, category.ShippedDate, category.RequiredDate));
            ///}
            
            return View();
        }
        }
}