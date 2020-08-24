using PriceBey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceBey.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            ViewBag.Products = db.ProductPrices.Where(a => a.IsActive == true).Count();
            ViewBag.Bookings = db.ProductBooking.Count();
            ViewBag.Subscribers = db.Subscribers.Count();
            ViewBag.Users = db.Users.Count();

            return View();
        }
    }
}