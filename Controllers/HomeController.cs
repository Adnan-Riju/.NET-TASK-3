using AR_Shopping.EF;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AR_Shopping.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ProjectEntities2();
            var data = db.SignUps.ToList();
            return View(data);

        }
        [HttpGet]
        public ActionResult SignUp()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUp s)
        {

            if (ModelState.IsValid)
            {  
                var db = new ProjectEntities2();
                db.SignUps.Add(s);
                db.SaveChanges();
                return View("Login");
                
            }
            return RedirectToAction("SignUp");
        }
        [HttpGet]
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login objuser)
        {
            if (ModelState.IsValid)
            {
                using (ProjectEntities2 db = new ProjectEntities2())
                {
                    var obj = db.SignUps.Where(a => a.UserName.Equals(objuser.UserName) && a.Password.Equals(objuser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                       // Session["UserID"] = obj.UserName.ToString();
                       // Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Dashboard");
                    }
                   
                }
            }
            return View();
        }
        public ActionResult Dashboard()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Create(SignUp I)
        {
            var db = new ProjectEntities2();
            db.SignUps.Add(I);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ProjectEntities2();
            var data = db.SignUps.Find(id);
           
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(SignUp d)
        {
            var db = new ProjectEntities2();
            var ex = db.SignUps.Find(d.Id);
            ex.Name = d.Name;
            db.SaveChanges();
            TempData["AllertMessage"] = "product updated";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new ProjectEntities2();
            var name = (from b in db.SignUps
                        where b.Id == id
                        select b).SingleOrDefault();
            db.SignUps.Remove(name);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}