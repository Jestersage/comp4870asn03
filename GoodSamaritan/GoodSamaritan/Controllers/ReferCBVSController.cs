using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoodSamaritan.Models.Client;
using GoodSamaritan.Models.Smart;

namespace GoodSamaritan.Controllers
{
    public class ReferCBVSController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: ReferCBVS
        public ActionResult Index()
        {
            return View(db.ReferCBVS.ToList());
        }

        // GET: ReferCBVS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferCBVS referCBVS = db.ReferCBVS.Find(id);
            if (referCBVS == null)
            {
                return HttpNotFound();
            }
            return View(referCBVS);
        }

        // GET: ReferCBVS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferCBVS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReferCBVSId,ReferCBVSValue")] ReferCBVS referCBVS)
        {
            if (ModelState.IsValid)
            {
                db.ReferCBVS.Add(referCBVS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(referCBVS);
        }

        // GET: ReferCBVS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferCBVS referCBVS = db.ReferCBVS.Find(id);
            if (referCBVS == null)
            {
                return HttpNotFound();
            }
            return View(referCBVS);
        }

        // POST: ReferCBVS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReferCBVSId,ReferCBVSValue")] ReferCBVS referCBVS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referCBVS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(referCBVS);
        }

        // GET: ReferCBVS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferCBVS referCBVS = db.ReferCBVS.Find(id);
            if (referCBVS == null)
            {
                return HttpNotFound();
            }
            return View(referCBVS);
        }

        // POST: ReferCBVS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReferCBVS referCBVS = db.ReferCBVS.Find(id);
            db.ReferCBVS.Remove(referCBVS);
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
