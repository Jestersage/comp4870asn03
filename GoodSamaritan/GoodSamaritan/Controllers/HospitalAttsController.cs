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
    public class HospitalAttsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: HospitalAtts
        public ActionResult Index()
        {
            return View(db.HospitalAtts.ToList());
        }

        // GET: HospitalAtts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalAtt hospitalAtt = db.HospitalAtts.Find(id);
            if (hospitalAtt == null)
            {
                return HttpNotFound();
            }
            return View(hospitalAtt);
        }

        // GET: HospitalAtts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HospitalAtts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HospitalAttId,HospitalAttName")] HospitalAtt hospitalAtt)
        {
            if (ModelState.IsValid)
            {
                db.HospitalAtts.Add(hospitalAtt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospitalAtt);
        }

        // GET: HospitalAtts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalAtt hospitalAtt = db.HospitalAtts.Find(id);
            if (hospitalAtt == null)
            {
                return HttpNotFound();
            }
            return View(hospitalAtt);
        }

        // POST: HospitalAtts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HospitalAttId,HospitalAttName")] HospitalAtt hospitalAtt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitalAtt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospitalAtt);
        }

        // GET: HospitalAtts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HospitalAtt hospitalAtt = db.HospitalAtts.Find(id);
            if (hospitalAtt == null)
            {
                return HttpNotFound();
            }
            return View(hospitalAtt);
        }

        // POST: HospitalAtts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HospitalAtt hospitalAtt = db.HospitalAtts.Find(id);
            db.HospitalAtts.Remove(hospitalAtt);
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
