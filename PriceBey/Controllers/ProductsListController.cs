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
            var data = db.Brands.ToList();

            return PartialView("_Brands", data);
        }

        public ActionResult Products()
        {
            // select * from products where id>0 and CategoryId = 2323 and price>=1 and price<=56;

            var data = db.Products.Include("Category").Include("Prices").Include("Prices.Store").
                Where(a=>a.Prices.Count > 0 && a.Prices.Where(c => c.IsActive
                == true).Any());

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

            if (Request.QueryString["q"] != null && !string.IsNullOrEmpty(Request.QueryString["q"]))
            {
                var q = Convert.ToString(Request.QueryString["q"]);

                data = data.Where(a => a.Name.Contains(q));
            }

            return PartialView("_Products", data.ToList());
        }

        public ActionResult AutoComplete(string Prefix)
        {
            try
            {
                var words = Prefix.ToLower().Trim();

                var data = db.Products.Include("Prices").Where(a => a.Name.Contains(words) && a.Prices.Count > 0 && a.Prices.Where(c => c.IsActive
                == true).Any()).Take(5)
                    .Select(a=>new {
                        a.ID,
                        a.Name,
                        Prices = a.Prices.Count
                    });

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}