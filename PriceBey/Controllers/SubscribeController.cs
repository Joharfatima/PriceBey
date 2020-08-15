using PriceBey.Models;
using System;
using System.Web.Mvc;

namespace PriceBey.Controllers
{
    public class SubscribeController : Controller
    {

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var email = Convert.ToString(collection["email"]);
            int result = 0;

            if (!string.IsNullOrEmpty(email))
            {
                using (var context = new ApplicationDbContext())
                {
                    var entity = new Subscriber();
                    entity.Email = email;
                    entity.isActive = true;

                    context.Subscribers.Add(entity);
                    result = context.SaveChanges();
                }
            }


            return Redirect(Request.Headers["Referer"].ToString() + "?subscriber=" + result);

        }
    }
}