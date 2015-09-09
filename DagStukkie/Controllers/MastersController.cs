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
    public class MastersController : Controller
    {
        private MasterContext db = new MasterContext();

        // GET: Masters
        public ActionResult Index()
        {
            return View(db.Dagstukkie.ToList());
        }

        // GET: Masters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Dagstukkie.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // GET: Masters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMaster,DateToday,BoodskapUID,GebedUID,GedagteUID,SkrifUID,TeksVersUID,TitelUID,ChangeDate")] Master master)
        {
            if (ModelState.IsValid)
            {
                db.Dagstukkie.Add(master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(master);
        }

        // GET: Masters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Dagstukkie.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // POST: Masters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMaster,DateToday,BoodskapUID,GebedUID,GedagteUID,SkrifUID,TeksVersUID,TitelUID,ChangeDate")] Master master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(master);
        }

        // GET: Masters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Dagstukkie.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // POST: Masters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Master master = db.Dagstukkie.Find(id);
            db.Dagstukkie.Remove(master);
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
