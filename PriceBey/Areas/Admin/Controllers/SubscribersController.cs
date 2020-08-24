using PriceBey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceBey.Areas.Admin.Controllers
{
    public class SubscribersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Subscribers
        public ActionResult Index()
        {
            return View(db.Subscribers);
        }
    }
}