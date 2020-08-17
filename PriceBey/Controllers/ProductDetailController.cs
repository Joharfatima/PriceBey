using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
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

            Product product =  db.Products.Include("Brand").Include("Category").Include("Prices")
                .Include("Prices.Store")
                .Where(a => a.ID ==id && a.Prices.Where(c => c.IsActive
                == true).Count()>0).Single();

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

       
    }
}