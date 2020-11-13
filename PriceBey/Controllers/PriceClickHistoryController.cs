using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PriceBey.Models;

namespace PriceBey.Controllers
{
    public class PriceClickHistoryController : Controller
    {

        [ValidateInput(false)]
        public ActionResult Create(int id, string url)
        {
            var ProductPriceId =id;
            int result = 0;
             if ((ProductPriceId) > 0)
                {
                using (var context = new ApplicationDbContext())
                {
                    var entity = new PriceClickHistory();
                    entity.ProductPriceId = ProductPriceId;
                    entity.CreatedDate = DateTime.Now;

                    context.PriceClickHistory.Add(entity);
                    result = context.SaveChanges();
                }
            }


            return RedirectPermanent(url); /*(Request.Headers["Referer"].ToString() + "?PriceClickHistory=" + result);*/

        }
    }
}