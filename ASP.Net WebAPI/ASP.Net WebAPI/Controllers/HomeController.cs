using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Net_WebAPI.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private Model1Container db = new Model1Container();
        public ActionResult Index()
        {

            ViewBag.Title = "Home Page";

            return View();


        }
        public ActionResult WebGrid()
        {

            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }
    }

}
