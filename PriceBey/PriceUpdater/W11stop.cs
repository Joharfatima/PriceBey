using PriceBey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace PriceBey.PriceUpdater
{
    public class W11stop
    {
        public async static Task Extract(ProductPrice product)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            product.IsActive = false;

            try
            {
                using (WebClient client = new WebClient())
                {
                    var html = client.DownloadString(product.Url);

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var stockNode = doc.DocumentNode.SelectSingleNode("//li[@class='product-stock in-stock']//span[contains(text(),'In Stock')]");

                    if (stockNode != null)
                    {
                        var orgNode = doc.DocumentNode.SelectSingleNode("//div[@class='price-wrapper']//div[@class='product-price']");

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