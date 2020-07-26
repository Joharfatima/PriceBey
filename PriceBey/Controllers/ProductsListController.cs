using PriceBey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceBey.Controllers
{
    public class ProductsListController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Categories()
        {
            return PartialView("_Categories",db.Categories.ToList());
        }
        public ActionResult Brands()
        {
            var data = db.Brands.Where(a => a.ID > 0);

            return PartialView("_Brands", data.ToList());
        }
        public ActionResult Products()
        {
            // select * from products where id>0 and CategoryId = 2323 and price>=1 and price<=56;

            var data = db.Products.Include("Category").Include("Prices").Include("Prices.Store").Where(a=>a.ID > 0);

            if (Request.QueryString["ct"] != null && !string.IsNullOrEmpty(Request.QueryString["ct"]))
            {
                var cId = Convert.ToInt32(Request.QueryString["ct"]);

                data = data.Where(a => a.CategoryId == cId);
            }

            if (Request.QueryString["br"] != null && !string.IsNullOrEmpty(Request.QueryString["br"]))
            {
                var bId = Convert.ToInt32(Request.QueryString["br"]);

                data = data.Where(a => a.BrandId == bId);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["min"]) && !string.IsNullOrEmpty(Request.QueryString["max"]))
            {
                var min = Convert.ToDecimal(Request.QueryString["min"]);
                var max = Convert.ToDecimal(Request.QueryString["max"]);

                data = data.Where(a => a.Prices.Where(c=>c.Price >= min && c.Price <=max).Any());
            }

            return PartialView("_Products", data.ToList());
        }
    }
}