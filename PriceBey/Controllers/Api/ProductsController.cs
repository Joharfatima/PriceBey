using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PriceBey.Models;
using System.Data.Entity;

namespace PriceBey.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext db;

        public ProductsController()
        {
            db = new ApplicationDbContext();
        }

        //[HttpGet]
        //public dynamic List()
        //{
        //    var products = db.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(a=>a.Prices).Include("Prices.Store");

        //    return products;
        //}


        [HttpGet]
        public dynamic Prices()
        {
            var products = db.ProductPrices.Include(p => p.Product).Include(p => p.Store);

            return products;
        }
    }
}
