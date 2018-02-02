using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        private ICustService Cust;
        private ICustService Cust2;
        public HomeController(ICustService cust, ICustService cust2)
        {
            this.Cust = cust;
            this.Cust2 = cust2;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            string sCust1 = Cust.getCust1();
            string sCust2 = Cust.getCust2();
            string sCust3 = Cust.getCust3();
            string sCust4 = Cust.getCust4();
            string sCust5 = Cust.getCust5();

            string sCust21 = Cust2.getCust1();
            string sCust22 = Cust2.getCust2();
            string sCust23 = Cust2.getCust3();
            string sCust24 = Cust2.getCust4();

            return View();
        }
    }
}
