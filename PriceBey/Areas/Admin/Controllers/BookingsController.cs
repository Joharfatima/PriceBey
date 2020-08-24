using PriceBey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceBey.Areas.Admin.Controllers
{
    public class BookingsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            var list = db.ProductBooking.Include("ProductPrice").Include("ProductPrice").Include("ProductPrice.Product");

            return View(list);
        }

        public ActionResult Detail(int id)
        {
            var list = db.ProductBooking.Include("ProductPrice").Include("ProductPrice").Include("ProductPrice.Product")
                .Where(a => a.ID == id).FirstOrDefault();

            return View(list);
        }

        [HttpPost]
        public ActionResult Detail(ProductBooking productBooking)
        {

            var booking = db.ProductBooking.Find(productBooking.ID);

            booking.Status = productBooking.Status;
            booking.Comments = productBooking.Comments;

            db.Entry(booking).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Detail", new { id = productBooking.ID });

            //var list = db.ProductBooking.Include("ProductPrice").Include("ProductPrice").Include("ProductPrice.Product")
            //    .Where(a => a.ID == productBooking.ID).FirstOrDefault();

            //return View(list);
        }
    }
}