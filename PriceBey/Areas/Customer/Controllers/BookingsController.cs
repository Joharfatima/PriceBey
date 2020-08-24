using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PriceBey.Models;

namespace PriceBey.Areas.Customer.Controllers
{
    public class BookingsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customer/Bookings

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var list = db.ProductBooking.Include("ProductPrice").Include("ProductPrice").Include("ProductPrice.Product")
                .Where(a => a.UserID == userId);

            return View(list);
        }

        public ActionResult Detail(int id)
        {
            var userId = User.Identity.GetUserId();

            var list = db.ProductBooking.Include("ProductPrice").Include("ProductPrice").Include("ProductPrice.Product")
                .Where(a =>a.ID == id && a.UserID == userId).FirstOrDefault();

            return View(list);
        }
    }
}