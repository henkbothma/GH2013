using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DagStukkie.Models;

namespace DagStukkie.Controllers
{
    public class SkrifsController : Controller
    {
        private SkrifContext db = new SkrifContext();

        // GET: Skrifs
        public ActionResult Index()
        {
            return View(db.Dagstukkie.ToList());
        }

        // GET: Skrifs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skrif skrif = db.Dagstukkie.Find(id);
            if (skrif == null)
            {
                return HttpNotFound();
            }
            return View(skrif);
        }

        // GET: Skrifs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skrifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSkrif,ChangeDate")] Skrif skrif)
        {
            if (ModelState.IsValid)
            {
                db.Dagstukkie.Add(skrif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skrif);
        }

        // GET: Skrifs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skrif skrif = db.Dagstukkie.Find(id);
            if (skrif == null)
            {
                return HttpNotFound();
            }
            return View(skrif);
        }

        // POST: Skrifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSkrif,ChangeDate")] Skrif skrif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skrif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skrif);
        }

        // GET: Skrifs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skrif skrif = db.Dagstukkie.Find(id);
            if (skrif == null)
            {
                return HttpNotFound();
            }
            return View(skrif);
        }

        // POST: Skrifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skrif skrif = db.Dagstukkie.Find(id);
            db.Dagstukkie.Remove(skrif);
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
