using PriceBey.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PriceBey.PriceUpdater
{
    public class Goto
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

                    var outOfStockNode = doc.DocumentNode.SelectSingleNode("//div[@class='product-out-of-stock']");

                    if (outOfStockNode == null)
                    {
                        var orgNode = doc.DocumentNode.SelectSingleNode("//span[@id='specialPriceBox']//span");

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