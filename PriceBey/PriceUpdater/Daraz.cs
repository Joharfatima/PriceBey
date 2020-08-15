﻿using PriceBey.Models;
using System;
using System.Threading.Tasks;

namespace PriceBey.PriceUpdater
{
    public class Daraz
    {
        public async static Task Extract(ProductPrice product)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            product.IsActive = false;

            try
            {
                var html = DownloadHTML.WebDriver(product.Url);

                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var orgNode = doc.DocumentNode.SelectSingleNode("//div[@id='module_product_price_1']//div[@class='pdp-product-price']/span[1]");

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