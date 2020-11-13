using PriceBey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceBey.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

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
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Products(int id)
        {
            var data = db.Products.Include("Category").Include("Prices").Include("Prices.Store")
                .Where(a => a.CategoryId == id 
               && a.Prices.Count> 0 
                && a.Prices.Where(c=>c.IsActive==true).Any()
                ).Take(8).ToList();

            // select * from products where categoryId = 1 and prices>0 and prices.isactive=true
            return PartialView("_Products", data);
        }
       
    }
}