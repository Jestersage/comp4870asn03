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
    public class MultiplePerpetratorsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: MultiplePerpetrators
        public ActionResult Index()
        {
            return View(db.MultiplePerpetrators.ToList());
        }

        // GET: MultiplePerpetrators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiplePerpetrator multiplePerpetrator = db.MultiplePerpetrators.Find(id);
            if (multiplePerpetrator == null)
            {
                return HttpNotFound();
            }
            return View(multiplePerpetrator);
        }

        // GET: MultiplePerpetrators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MultiplePerpetrators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MultiplePerpetratorId,MultiplePerpetratorValue")] MultiplePerpetrator multiplePerpetrator)
        {
            if (ModelState.IsValid)
            {
                db.MultiplePerpetrators.Add(multiplePerpetrator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(multiplePerpetrator);
        }

        // GET: MultiplePerpetrators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiplePerpetrator multiplePerpetrator = db.MultiplePerpetrators.Find(id);
            if (multiplePerpetrator == null)
            {
                return HttpNotFound();
            }
            return View(multiplePerpetrator);
        }

        // POST: MultiplePerpetrators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MultiplePerpetratorId,MultiplePerpetratorValue")] MultiplePerpetrator multiplePerpetrator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multiplePerpetrator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(multiplePerpetrator);
        }

        // GET: MultiplePerpetrators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultiplePerpetrator multiplePerpetrator = db.MultiplePerpetrators.Find(id);
            if (multiplePerpetrator == null)
            {
                return HttpNotFound();
            }
            return View(multiplePerpetrator);
        }

        // POST: MultiplePerpetrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MultiplePerpetrator multiplePerpetrator = db.MultiplePerpetrators.Find(id);
            db.MultiplePerpetrators.Remove(multiplePerpetrator);
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
