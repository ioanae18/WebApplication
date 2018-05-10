using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emilia.Flowers.Models;

namespace Emilia.Flowers.Controllers
{
    public class FlowersController : Controller
    {
        private EmiliaFlowersContext db = new EmiliaFlowersContext();

        // GET: Flowers
        public ActionResult Index()
        {
            return View(db.Flowers.ToList());
        }

        // GET: Flowers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flowers = db.Flowers.Find(id);
            if (flowers == null)
            {
                return HttpNotFound();
            }
            return View(flowers);
        }

        // GET: Flowers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price")] Flower flowers)
        {
            if (ModelState.IsValid)
            {
                db.Flowers.Add(flowers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flowers);
        }

        // GET: Flowers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flowers = db.Flowers.Find(id);
            if (flowers == null)
            {
                return HttpNotFound();
            }
            return View(flowers);
        }

        // POST: Flowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price")] Flower flowers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flowers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flowers);
        }

        // GET: Flowers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flowers = db.Flowers.Find(id);
            if (flowers == null)
            {
                return HttpNotFound();
            }
            return View(flowers);
        }

        // POST: Flowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flower flowers = db.Flowers.Find(id);
            db.Flowers.Remove(flowers);
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
