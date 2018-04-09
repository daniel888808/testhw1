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
        public ActionResult SearchOrder()
        {
            Models.AllService allService = new Models.AllService();
            var result = allService.GetOrdersByCondition(new Models.SalesOrder());
            ViewBag.SelectEmployee = '<select name="carlist" form="">< option value = "audi" > Audi</ option ></ select > ';
            ViewBag.SelectCompony = '';
            return View();
        }
    }
}