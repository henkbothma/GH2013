using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DagStukkie.DAL;
using DagStukkie.Models;

namespace DagStukkie.Controllers
{
    public class GebedsController : Controller
    {
        private DagStukkieContext db = new DagStukkieContext();

        // GET: Gebeds
        public ActionResult Index()
        {
            return View(db.Gebed.ToList());
        }

        // GET: Gebeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gebed gebed = db.Gebed.Find(id);
            if (gebed == null)
            {
                return HttpNotFound();
            }
            return View(gebed);
        }

        // GET: Gebeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gebeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GebedID,GebedsTeks,ChangeOperator,ChangeDate,Status")] Gebed gebed)
        {
            if (ModelState.IsValid)
            {
                db.Gebed.Add(gebed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gebed);
        }

        // GET: Gebeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gebed gebed = db.Gebed.Find(id);
            if (gebed == null)
            {
                return HttpNotFound();
            }
            return View(gebed);
        }

        // POST: Gebeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GebedID,GebedsTeks,ChangeOperator,ChangeDate,Status")] Gebed gebed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gebed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gebed);
        }

        // GET: Gebeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gebed gebed = db.Gebed.Find(id);
            if (gebed == null)
            {
                return HttpNotFound();
            }
            return View(gebed);
        }

        // POST: Gebeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gebed gebed = db.Gebed.Find(id);
            db.Gebed.Remove(gebed);
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
