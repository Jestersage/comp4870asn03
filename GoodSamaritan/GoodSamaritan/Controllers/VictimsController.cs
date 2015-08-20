using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoodSamaritan.Models.Client;

namespace GoodSamaritan.Controllers
{
    public class VictimsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Victims
        public ActionResult Index()
        {
            return View(db.Victims.ToList());
        }

        // GET: Victims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Victim victim = db.Victims.Find(id);
            if (victim == null)
            {
                return HttpNotFound();
            }
            return View(victim);
        }

        // GET: Victims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Victims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VictimId,VictimType")] Victim victim)
        {
            if (ModelState.IsValid)
            {
                db.Victims.Add(victim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(victim);
        }

        // GET: Victims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Victim victim = db.Victims.Find(id);
            if (victim == null)
            {
                return HttpNotFound();
            }
            return View(victim);
        }

        // POST: Victims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VictimId,VictimType")] Victim victim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(victim);
        }

        // GET: Victims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Victim victim = db.Victims.Find(id);
            if (victim == null)
            {
                return HttpNotFound();
            }
            return View(victim);
        }

        // POST: Victims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Victim victim = db.Victims.Find(id);
            db.Victims.Remove(victim);
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
