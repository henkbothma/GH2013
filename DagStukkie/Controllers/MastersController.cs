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
    public class MastersController : Controller
    {
        private DagStukkieContext db = new DagStukkieContext();

        // GET: Masters
        public ActionResult Index()
        {
            var master = db.Master.Include(m => m.Boodskap).Include(m => m.Gebed).Include(m => m.Gedagte).Include(m => m.Skrif).Include(m => m.TeksVers).Include(m => m.Titel);
            return View(master.ToList());
        }

        // GET: Masters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Master.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            return View(master);
        }

        // GET: Masters/Create
        public ActionResult Create()
        {
            ViewBag.BoodskapID = new SelectList(db.Boodskap, "BoodskapID", "BoodskapTeks");
            ViewBag.GebedID = new SelectList(db.Gebed, "GebedID", "GebedsTeks");
            ViewBag.GedagteID = new SelectList(db.Gedagte, "GedagteID", "GedagteTeks");
            ViewBag.SkrifID = new SelectList(db.Skrif, "SkrifID", "SkrifTeks");
            ViewBag.TeksVersID = new SelectList(db.TeksVers, "TeksVersID", "TeksVersNommer");
            ViewBag.TitelID = new SelectList(db.Titel, "TitelID", "TitelTeks");
            return View();
        }

        // POST: Masters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MasterID,BoodskapID,GebedID,GedagteID,SkrifID,TeksVersID,TitelID,ChangeOperator,Status")] Master master)
        {
            if (ModelState.IsValid)
            {
                db.Master.Add(master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BoodskapID = new SelectList(db.Boodskap, "BoodskapID", "BoodskapTeks", master.BoodskapID);
            ViewBag.GebedID = new SelectList(db.Gebed, "GebedID", "GebedsTeks", master.GebedID);
            ViewBag.GedagteID = new SelectList(db.Gedagte, "GedagteID", "GedagteTeks", master.GedagteID);
            ViewBag.SkrifID = new SelectList(db.Skrif, "SkrifID", "SkrifTeks", master.SkrifID);
            ViewBag.TeksVersID = new SelectList(db.TeksVers, "TeksVersID", "TeksVersNommer", master.TeksVersID);
            ViewBag.TitelID = new SelectList(db.Titel, "TitelID", "TitelTeks", master.TitelID);
            return View(master);
        }

        // GET: Masters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Master.Find(id);
            if (master == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoodskapID = new SelectList(db.Boodskap, "BoodskapID", "BoodskapTeks", master.BoodskapID);
            ViewBag.GebedID = new SelectList(db.Gebed, "GebedID", "GebedsTeks", master.GebedID);
            ViewBag.GedagteID = new SelectList(db.Gedagte, "GedagteID", "GedagteTeks", master.GedagteID);
            ViewBag.SkrifID = new SelectList(db.Skrif, "SkrifID", "SkrifTeks", master.SkrifID);
            ViewBag.TeksVersID = new SelectList(db.TeksVers, "TeksVersID", "TeksVersNommer", master.TeksVersID);
            ViewBag.TitelID = new SelectList(db.Titel, "TitelID", "TitelTeks", master.TitelID);
            return View(master);
        }

        // POST: Masters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MasterID,BoodskapID,GebedID,GedagteID,SkrifID,TeksVersID,TitelID,ChangeOperator,Status")] Master master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BoodskapID = new SelectList(db.Boodskap, "BoodskapID", "BoodskapTeks", master.BoodskapID);
            ViewBag.GebedID = new SelectList(db.Gebed, "GebedID", "GebedsTeks", master.GebedID);
            ViewBag.GedagteID = new SelectList(db.Gedagte, "GedagteID", "GedagteTeks", master.GedagteID);
            ViewBag.SkrifID = new SelectList(db.Skrif, "SkrifID", "SkrifTeks", master.SkrifID);
            ViewBag.TeksVersID = new SelectList(db.TeksVers, "TeksVersID", "TeksVersNommer", master.TeksVersID);
            ViewBag.TitelID = new SelectList(db.Titel, "TitelID", "TitelTeks", master.TitelID);
            return View(master);
        }

        // GET: Masters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Master master = db.Master.Find(id);
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
            Master master = db.Master.Find(id);
            db.Master.Remove(master);
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
