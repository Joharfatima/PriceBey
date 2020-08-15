using PriceBey.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PriceBey.Areas.Admin.Controllers
{
    public class ProductPricesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductPrices
        public ActionResult Index()
        {
            var productPrices = db.ProductPrices.Include(p => p.Product).Include(p => p.Store).OrderBy(a => a.ProductId);
            return View(productPrices.ToList());
        }

        // GET: ProductPrices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPrice productPrice = db.ProductPrices.Find(id);
            if (productPrice == null)
            {
                return HttpNotFound();
            }
            return View(productPrice);
        }

        // GET: ProductPrices/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ID", "Name");
            ViewBag.StoreId = new SelectList(db.Stores, "ID", "Name");
            return View();
        }

        // POST: ProductPrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Price,Url,ProductId,IsActive,StoreId")] ProductPrice productPrice)
        {
            if (ModelState.IsValid)
            {
                db.ProductPrices.Add(productPrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ID", "Name", productPrice.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "ID", "Name", productPrice.StoreId);
            return View(productPrice);
        }

        // GET: ProductPrices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPrice productPrice = db.ProductPrices.Find(id);
            if (productPrice == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ID", "Name", productPrice.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "ID", "Name", productPrice.StoreId);
            return View(productPrice);
        }

        // POST: ProductPrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Price,Url,ProductId,IsActive,StoreId")] ProductPrice productPrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productPrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ID", "Name", productPrice.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "ID", "Name", productPrice.StoreId);
            return View(productPrice);
        }

        // GET: ProductPrices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductPrice productPrice = db.ProductPrices.Find(id);
            if (productPrice == null)
            {
                return HttpNotFound();
            }
            return View(productPrice);
        }

        // POST: ProductPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductPrice productPrice = db.ProductPrices.Find(id);
            db.ProductPrices.Remove(productPrice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
