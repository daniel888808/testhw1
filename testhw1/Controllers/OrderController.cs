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
    }
}