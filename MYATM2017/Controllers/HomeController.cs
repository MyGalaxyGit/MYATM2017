using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MYATM2017.Models;
using Microsoft.AspNet.Identity;

namespace MYATM2017.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [MyLoggingFilter]
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c=>c.ApplicationUserId==userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having some trouble? Send us a message!";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string  message)
        {
            ViewBag.TheMessage = "Thanks, We got Your Message !!!!";

            return View();
        }
        public ActionResult Serial(string letterCase) {
            var serial = "ASPNETMVC17 ";
            if (letterCase=="lower")
            {
                return Content(serial.ToLower());
            }
            else
            {
                return Content(serial.ToUpper());
                //return Json(new { name="Serial", value=serial},JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            
        }
    }
}