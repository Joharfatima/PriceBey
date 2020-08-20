using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PriceBey.Models;

namespace PriceBey.Areas.Admin.Controllers
{
    public class PriceClickHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PriceClickHistories
        public ActionResult Index()
        {
            var priceClickHistory = db.PriceClickHistory.Include(p => p.ProductPrice);
            return View(priceClickHistory.ToList());
        }

        // GET: Admin/PriceClickHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceClickHistory priceClickHistory = db.PriceClickHistory.Find(id);
            if (priceClickHistory == null)
            {
                return HttpNotFound();
            }
            return View(priceClickHistory);
        }

        // GET: Admin/PriceClickHistories/Create
        public ActionResult Create()
        {
            ViewBag.ProductPriceId = new SelectList(db.ProductPrices, "ID", "Url");
            return View();
        }

        // POST: Admin/PriceClickHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductPriceId,CreatedDate")] PriceClickHistory priceClickHistory)
        {
            if (ModelState.IsValid)
            {
                db.PriceClickHistory.Add(priceClickHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductPriceId = new SelectList(db.ProductPrices, "ID", "Url", priceClickHistory.ProductPriceId);
            return View(priceClickHistory);
        }

        // GET: Admin/PriceClickHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceClickHistory priceClickHistory = db.PriceClickHistory.Find(id);
            if (priceClickHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductPriceId = new SelectList(db.ProductPrices, "ID", "Url", priceClickHistory.ProductPriceId);
            return View(priceClickHistory);
        }

        // POST: Admin/PriceClickHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductPriceId,CreatedDate")] PriceClickHistory priceClickHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceClickHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductPriceId = new SelectList(db.ProductPrices, "ID", "Url", priceClickHistory.ProductPriceId);
            return View(priceClickHistory);
        }

        // GET: Admin/PriceClickHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceClickHistory priceClickHistory = db.PriceClickHistory.Find(id);
            if (priceClickHistory == null)
            {
                return HttpNotFound();
            }
            return View(priceClickHistory);
        }

        // POST: Admin/PriceClickHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PriceClickHistory priceClickHistory = db.PriceClickHistory.Find(id);
            db.PriceClickHistory.Remove(priceClickHistory);
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
