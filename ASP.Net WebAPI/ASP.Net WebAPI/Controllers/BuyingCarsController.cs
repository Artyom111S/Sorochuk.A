using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.Net_WebAPI.Models;

namespace ASP.Net_WebAPI.Controllers
{
    public class BuyingCarsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: BuyingCars
        public ActionResult Index()
        {
            var buyingCarSet = db.BuyingCarSet.Include(b => b.SellingAuto);
            return View(buyingCarSet.ToList());
        }

        // GET: BuyingCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyingCar buyingCar = db.BuyingCarSet.Find(id);
            if (buyingCar == null)
            {
                return HttpNotFound();
            }
            return View(buyingCar);
        }

        // GET: BuyingCars/Create
        public ActionResult Create()
        {
            ViewBag.SellingAutoId = new SelectList(db.Selling_auto, "Id", "AutoDescription");
            return View();
        }

        // POST: BuyingCars/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataClient,Cost,DatePurchase,SellingAutoId")] BuyingCar buyingCar)
        {
            if (ModelState.IsValid)
            {
                db.BuyingCarSet.Add(buyingCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SellingAutoId = new SelectList(db.Selling_auto, "Id", "AutoDescription", buyingCar.SellingAutoId);
            return View(buyingCar);
        }

        // GET: BuyingCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyingCar buyingCar = db.BuyingCarSet.Find(id);
            if (buyingCar == null)
            {
                return HttpNotFound();
            }
            ViewBag.SellingAutoId = new SelectList(db.Selling_auto, "Id", "AutoDescription", buyingCar.SellingAutoId);
            return View(buyingCar);
        }

        // POST: BuyingCars/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataClient,Cost,DatePurchase,SellingAutoId")] BuyingCar buyingCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyingCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SellingAutoId = new SelectList(db.Selling_auto, "Id", "AutoDescription", buyingCar.SellingAutoId);
            return View(buyingCar);
        }

        // GET: BuyingCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyingCar buyingCar = db.BuyingCarSet.Find(id);
            if (buyingCar == null)
            {
                return HttpNotFound();
            }
            return View(buyingCar);
        }

        // POST: BuyingCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyingCar buyingCar = db.BuyingCarSet.Find(id);
            db.BuyingCarSet.Remove(buyingCar);
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
