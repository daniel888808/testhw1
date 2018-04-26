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
            EmpItems.Add(new SelectListItem()
            {
                Text = "不選員工",
                Value = "0"
            });
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
            ShipperItems.Add(new SelectListItem()
            {
                Text = "不選公司",
                Value = "0"
            }
                    );
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
            int? OrderIDint=null;
            int? SelectEmployeeint =0;
            int? SelectComponyint = 0;
            string OrderID = post["OrderID"];
            string SelectEmployee = post["SelectEmployee"];
            string SelectCompony = post["SelectCompony"];
            string ContactName = post["ContactName"];
            string OderDatetext = post["OderDate"];
            string ShipperDatetext = post["ShipperDate"];
            string RequiredDatetext = post["RequiredDate"];
            //DateTime OderDate = new DateTime(1000, 1, 1);
            //DateTime ShipperDate = new DateTime(1000, 1, 1);
            //DateTime RequiredDate = new DateTime(1000, 1, 1);

            try
            {
                OrderIDint = Int32.Parse(OrderID);
                SelectEmployeeint = Int32.Parse(SelectEmployee);
                SelectComponyint = Int32.Parse(SelectCompony);
                //OderDate = DateTime.Parse(OderDatetext);
                //ShipperDate = DateTime.Parse(ShipperDatetext);
                //RequiredDate = DateTime.Parse(RequiredDatetext);
                //String.Format("{0:yyyy/MM/dd}", OderDate);
                //String.Format("{0:yyyy/MM/dd}", ShipperDate);
                //String.Format("{0:yyyy/MM/dd}", RequiredDate);


            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            
            
            ///待加例外處理
            ///var OrderResult = allService.GetOrdersByCondition(new Models.SalesOrder());
            IEnumerable<Models.HrEmployees> EmployeeResult = allService.GetEmployeesByCondition(new Models.HrEmployees());
            IEnumerable<Models.SalesCustomers> CustomersResult = allService.GetCustomersByCondition(new Models.SalesCustomers() {});
            IEnumerable<Models.SalesShippers> ShiperResult = allService.GetShiperByCondition(new Models.SalesShippers());
            IEnumerable<Models.SalesOrder> OrderResult = allService.GetOrdersByCondition(new Models.SalesOrder()); ;
            IEnumerable<Models.SalesOrder> result=null;
            ///orderid查
            if (!string.IsNullOrWhiteSpace(OrderID))
            {
                result = OrderResult.Where(m => OrderIDint.Equals(m.OrderID)).ToList();
            }
            ///客戶名稱查
            if (!string.IsNullOrWhiteSpace(ContactName))
            {
                result =
                    from o in OrderResult
                    join c in CustomersResult on o.CustomerID equals c.CustomerID
                    where c.CompanyName.Contains(ContactName)
                    select o;
                ///List<Models.SalesCustomers> Customername = CustomersResult.Where(m => ContactName.Contains(m.ContactName)).ToList();
                ///result = OrderResult.Where(m => Customername.Equals(m.CustomerID)).ToList();
            }
            /// 員工查
            if (SelectEmployeeint != 0)
            {
                result = OrderResult.Where(m => SelectEmployeeint.Equals(m.EmployeeID)).ToList();
            }
            /// 公司查
            if (SelectComponyint != 0)
            {
                result = OrderResult.Where(m => SelectComponyint.Equals(m.CustomerID)).ToList();
            }
            ///// 訂購日期查
            //if (OderDate !=(1000, 1, 1))
            //{
            //    result = OrderResult.Where(m => SelectComponyint.Equals(m.CustomerID)).ToList();
            //}
            ///// 出貨日期查
            //if (SelectComponyint != 0)
            //{
            //    result = OrderResult.Where(m => SelectComponyint.Equals(m.CustomerID)).ToList();
            //}
            ///// 需要日期查
            //if (SelectComponyint != 0)
            //{
            //    result = OrderResult.Where(m => SelectComponyint.Equals(m.CustomerID)).ToList();
            //}
            ViewBag.Result = result;
            ViewBag.test= OderDatetext;

            return View();
        }

        public ActionResult NewOrders(FormCollection post)
        {
            Models.AllService allService = new Models.AllService();
            IEnumerable<Models.HrEmployees> EmployeeResult = allService.GetEmployeesByCondition(new Models.HrEmployees());
            IEnumerable<Models.SalesCustomers> CustomersResult = allService.GetCustomersByCondition(new Models.SalesCustomers() { });
            IEnumerable<Models.SalesShippers> ShiperResult = allService.GetShiperByCondition(new Models.SalesShippers());
            IEnumerable<Models.SalesOrder> OrderResult = allService.GetOrdersByCondition(new Models.SalesOrder()); ;
            IEnumerable<Models.SalesOrder> result = null;
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
            ///客戶的Select
            List<SelectListItem> SelectCustomer = new List<SelectListItem>();
            foreach (var category in ShiperResult)
            {
                SelectCustomer.Add(new SelectListItem()
                {
                    Text = category.CompanyName,
                    Value = category.ShipperID.ToString()
                }
                    );
            }
            ViewBag.SelectEmployee = EmpItems;
            ViewBag.SelectCompony = ShipperItems;
            ViewBag.SelectCustomer = SelectCustomer;
            ViewBag.Result = result;
            return View();
        }
    }
}