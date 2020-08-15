using PriceBey.Models;
using System.Linq;
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
        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }


        public ActionResult Terms()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Products(int id)
        {
            var data = db.Products.Include("Category").Include("Prices").Include("Prices.Store")
                .Where(a => a.CategoryId == id && a.Prices.Count > 0).Take(8).ToList();

            return PartialView("_Products", data);
        }


    }
}