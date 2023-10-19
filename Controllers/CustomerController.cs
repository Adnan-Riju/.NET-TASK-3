using AR_Shopping.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AR_Shopping.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Customer_Dashboard()
        {
            var db = new ProjectEntities2();
            var data = db.tbl_Product.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Product_Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult  Product_Details(tbl_Product i)
        {

            var db = new ProjectEntities2();
            var data2 = db.tbl_Product.ToList();
            return View(data2);
        }

        }
}
  