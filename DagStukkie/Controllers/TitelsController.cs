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
    public class TitelsController : Controller
    {
        private DagStukkieContext db = new DagStukkieContext();

        // GET: Titels
        public ActionResult Index()
        {
            return View(db.Titel.ToList());
        }

        // GET: Titels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Titel titel = db.Titel.Find(id);
            if (titel == null)
            {
                return HttpNotFound();
            }
            return View(titel);
        }

        // GET: Titels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Titels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TitelID,TitelTeks,ChangeOperator,ChangeDate,Status")] Titel titel)
        {
            if (ModelState.IsValid)
            {
                db.Titel.Add(titel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(titel);
        }

        // GET: Titels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Titel titel = db.Titel.Find(id);
            if (titel == null)
            {
                return HttpNotFound();
            }
            return View(titel);
        }

        // POST: Titels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TitelID,TitelTeks,ChangeOperator,ChangeDate,Status")] Titel titel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(titel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(titel);
        }

        // GET: Titels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Titel titel = db.Titel.Find(id);
            if (titel == null)
            {
                return HttpNotFound();
            }
            return View(titel);
        }

        // POST: Titels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Titel titel = db.Titel.Find(id);
            db.Titel.Remove(titel);
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
