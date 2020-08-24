using System.Web.Mvc;

namespace PriceBey.Areas.Customer
{
    public class CustomerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Customer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Customer_default",
                "Customer/{controller}/{action}/{id}",
                new { controller = "Bookings", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}