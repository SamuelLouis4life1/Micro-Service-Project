using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Contexts;
using ProductMicroservice.Core.Model;

namespace WebAppOnlineStore.Controllers

{
    [Authorize]
    public class CartsController : Controller
    {
        private OnlineStoreContexts db = new OnlineStoreContexts();

        // GET: Carts
        public ActionResult Index()
        {
            return View(db.Carts.ToList());
        }

        // GET: Carts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carts carts = db.Carts.Find(id);
            if (carts == null)
            {
                return HttpNotFound();
            }
            return View(carts);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Amount")] Carts carts)
        {
            if (ModelState.IsValid)
            {
                carts.Id = Guid.NewGuid();
                db.Carts.Add(carts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carts);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carts carts = db.Carts.Find(id);
            if (carts == null)
            {
                return HttpNotFound();
            }
            return View(carts);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Amount")] Carts carts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carts);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carts carts = db.Carts.Find(id);
            if (carts == null)
            {
                return HttpNotFound();
            }
            return View(carts);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Carts carts = db.Carts.Find(id);
            db.Carts.Remove(carts);
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
