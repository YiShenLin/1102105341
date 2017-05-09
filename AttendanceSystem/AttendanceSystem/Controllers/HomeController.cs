using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AttendaceRecrod()
        {
            var RecrodList = new List<AttendanceSystem.Models.GetString>();
            RecrodList = AttendanceSystem.Models.Service.GetJsonFunction();
            return View(RecrodList);
        }
    }
}