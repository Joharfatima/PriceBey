using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using PriceBey.Models;

namespace PriceBey.Areas.Admin.Controllers
{
    public class ProductsServiceController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        static int logCount = 0;

        // GET: Admin/ProductsService
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> UpdatePrice(int id)
        {
            var product = db.ProductPrices.Find(id);

            if (product.StoreId == 2)
            {
                await PriceUpdater.Daraz.Extract(product);
            }
            else if (product.StoreId == 3)
            {
                await PriceUpdater.Telemart.Extract(product);
            }
            else if (product.StoreId == 4)
            {
                await PriceUpdater.Goto.Extract(product);
            }
            else if (product.StoreId == 5)
            {
                await PriceUpdater.Homeshop.Extract(product);
            }
            else if (product.StoreId == 6)
            {
                await PriceUpdater.Shophive.Extract(product);
            }
            else if (product.StoreId == 7)
            {
                await PriceUpdater.iShop.Extract(product);
            }
            else if (product.StoreId == 8)
            {
                await PriceUpdater.Mega.Extract(product);
            }
            else if (product.StoreId == 10)
            {
                await PriceUpdater.Symbios.Extract(product);
            }
            else if (product.StoreId == 11)
            {
                await PriceUpdater.Myshop.Extract(product);
            }
            else if (product.StoreId == 12)
            {
                await PriceUpdater.PriceOye.Extract(product);
            }
            else if (product.StoreId == 14)
            {
                await PriceUpdater.W11stop.Extract(product);
            }

            return Json(product, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UpdateAlll(string ids)
        {
            var productsIds = ids.Split(',').Select(a => int.Parse(a)).ToArray();

            HostingEnvironment.QueueBackgroundWorkItem(ct => workItemAsync(ct, productsIds));

            return Json("", JsonRequestBehavior.AllowGet);
        }

        private async Task<CancellationToken> workItemAsync(CancellationToken ct, int[] productIds)
        {
            logCount++;
            int currentLogCount = logCount;

            await addLogAsync(ct, currentLogCount, productIds);
            return ct;
        }

        private async Task<CancellationToken> addLogAsync(CancellationToken ct, int currentLogCount, int[] productIds)
        {

            try
            {
                for (int i = 0; i < productIds.Count(); i++)
                {
                    var product = db.ProductPrices.Find(productIds[i]);

                    if (product.StoreId == 5)
                    {
                        await PriceUpdater.Homeshop.Extract(product);
                    }
                    else if (product.StoreId == 7)
                    {
                        await PriceUpdater.iShop.Extract(product);
                    }
                    else if (product.StoreId == 8)
                    {
                        await PriceUpdater.Mega.Extract(product);
                    }
                    else if (product.StoreId == 12)
                    {
                        await PriceUpdater.PriceOye.Extract(product);
                    }
                    else if (product.StoreId == 2)
                    {
                        await PriceUpdater.Daraz.Extract(product);
                    }

                    await Task.Delay(2000, ct);
                }
            }
            catch (TaskCanceledException tce)
            {
                Trace.TraceError("Caught TaskCanceledException - signaled cancellation " + tce.Message);
            }

            return ct;
        }
    }
}