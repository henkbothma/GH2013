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
    public class GedagtesController : Controller
    {
        private DagStukkieContext db = new DagStukkieContext();

        // GET: Gedagtes
        public ActionResult Index()
        {
            return View(db.Gedagte.ToList());
        }

        // GET: Gedagtes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gedagte gedagte = db.Gedagte.Find(id);
            if (gedagte == null)
            {
                return HttpNotFound();
            }
            return View(gedagte);
        }

        // GET: Gedagtes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gedagtes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GedagteID,GedagteTeks,ChangeOperator,Status")] Gedagte gedagte)
        {
            if (ModelState.IsValid)
            {
                db.Gedagte.Add(gedagte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gedagte);
        }

        // GET: Gedagtes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gedagte gedagte = db.Gedagte.Find(id);
            if (gedagte == null)
            {
                return HttpNotFound();
            }
            return View(gedagte);
        }

        // POST: Gedagtes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GedagteID,GedagteTeks,ChangeOperator,Status")] Gedagte gedagte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gedagte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gedagte);
        }

        // GET: Gedagtes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gedagte gedagte = db.Gedagte.Find(id);
            if (gedagte == null)
            {
                return HttpNotFound();
            }
            return View(gedagte);
        }

        // POST: Gedagtes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gedagte gedagte = db.Gedagte.Find(id);
            db.Gedagte.Remove(gedagte);
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
