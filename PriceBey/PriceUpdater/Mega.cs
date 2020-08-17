using PriceBey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PriceBey.PriceUpdater
{
    public class Mega
    {
        public async static Task Extract(ProductPrice product)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            product.IsActive = false;

            try
            {
                var html = DownloadHTML.Client(product.Url);

                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var orgNode = doc.DocumentNode.SelectSingleNode("//div[@class='price-n-action']//span[@itemprop='price']");

                if (orgNode != null)
                {
                    var priceText = orgNode.InnerText;

                    var price = DownloadHTML.StringToDecimal(priceText);

                    if (price > 0)
                    {
                        product.Price = price;
                        product.IsActive = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            db.Entry(product).State = System.Data.Entity.EntityState.Modified;

            await db.SaveChangesAsync();
        }
    }
}