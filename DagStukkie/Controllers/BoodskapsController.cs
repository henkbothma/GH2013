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
    public class BoodskapsController : Controller
    {
        private DagStukkieContext db = new DagStukkieContext();

        // GET: Boodskaps
        public ActionResult Index()
        {
            return View(db.Boodskap.ToList());
        }

        // GET: Boodskaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boodskap boodskap = db.Boodskap.Find(id);
            if (boodskap == null)
            {
                return HttpNotFound();
            }
            return View(boodskap);
        }

        // GET: Boodskaps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boodskaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoodskapID,BoodskapTeks,ChangeOperator,Status")] Boodskap boodskap)
        {
            if (ModelState.IsValid)
            {
                db.Boodskap.Add(boodskap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boodskap);
        }

        // GET: Boodskaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boodskap boodskap = db.Boodskap.Find(id);
            if (boodskap == null)
            {
                return HttpNotFound();
            }
            return View(boodskap);
        }

        // POST: Boodskaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoodskapID,BoodskapTeks,ChangeOperator,Status")] Boodskap boodskap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boodskap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boodskap);
        }

        // GET: Boodskaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boodskap boodskap = db.Boodskap.Find(id);
            if (boodskap == null)
            {
                return HttpNotFound();
            }
            return View(boodskap);
        }

        // POST: Boodskaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boodskap boodskap = db.Boodskap.Find(id);
            db.Boodskap.Remove(boodskap);
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
