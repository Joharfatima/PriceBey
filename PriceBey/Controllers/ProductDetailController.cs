using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using Microsoft.AspNet.Identity;
using PriceBey.Models;

namespace PriceBey.Controllers
{
    public class ProductDetailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: ProductDetail
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Include("Brand").Include("Category").Include("Prices")
                .Include("Prices.Store")
                .Where(a => a.ID == id && a.Prices.Where(c => c.IsActive
                 == true).Count() > 0).Single();

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Booking(ProductBooking model)
        {
            if(ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.Status = "Pending";
                model.UserID = User.Identity.GetUserId();

                db.ProductBooking.Add(model);

                var r = db.SaveChanges();

                if(r > 0)
                {
                    return RedirectToAction("Result", "Booking", new { id = model.ID });
                }
            }

            return Redirect(Request.UrlReferrer.PathAndQuery + "#FailedBooking");


        }

    }
}