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
    public class MVCController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: MVC
        public ActionResult Index()
        {
            return View(db.Selling_auto.ToList());
        }

        // GET: MVC/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //   Selling_Auto продажа_авто = db.Selling_auto.Find(id);
        //    if (продажа_авто == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(продажа_авто);
        //}

        // GET: MVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVC/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SellingAuto sellingAuto)
        {
            if (ModelState.IsValid)
            {
                db.Selling_auto.Add(sellingAuto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sellingAuto);
        }

        //// GET: MVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellingAuto sellingAuto = db.Selling_auto.Find(id);
            if (sellingAuto == null)
            {
                return HttpNotFound();
            }
            return View(sellingAuto);
        }

        // POST: MVC/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SellingAuto sellingAuto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellingAuto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sellingAuto);
        }

        //// GET: MVC/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Selling_Auto продажа_авто = db.Selling_auto.Find(id);
        //    if (продажа_авто == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(продажа_авто);
        //}

        //// POST: MVC/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Selling_Auto продажа_авто = db.Selling_auto.Find(id);
        //    db.Selling_auto.Remove(продажа_авто);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
