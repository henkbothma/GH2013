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
    public class TeksVersController : Controller
    {
        private DagStukkieContext db = new DagStukkieContext();

        // GET: TeksVers
        public ActionResult Index()
        {
            return View(db.TeksVers.ToList());
        }

        // GET: TeksVers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeksVers teksVers = db.TeksVers.Find(id);
            if (teksVers == null)
            {
                return HttpNotFound();
            }
            return View(teksVers);
        }

        // GET: TeksVers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeksVers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeksVersID,TeksVersNommer,TeksVersTeks,ChangeOperator,ChangeDate,Status")] TeksVers teksVers)
        {
            if (ModelState.IsValid)
            {
                db.TeksVers.Add(teksVers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teksVers);
        }

        // GET: TeksVers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeksVers teksVers = db.TeksVers.Find(id);
            if (teksVers == null)
            {
                return HttpNotFound();
            }
            return View(teksVers);
        }

        // POST: TeksVers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeksVersID,TeksVersNommer,TeksVersTeks,ChangeOperator,ChangeDate,Status")] TeksVers teksVers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teksVers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teksVers);
        }

        // GET: TeksVers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeksVers teksVers = db.TeksVers.Find(id);
            if (teksVers == null)
            {
                return HttpNotFound();
            }
            return View(teksVers);
        }

        // POST: TeksVers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeksVers teksVers = db.TeksVers.Find(id);
            db.TeksVers.Remove(teksVers);
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
