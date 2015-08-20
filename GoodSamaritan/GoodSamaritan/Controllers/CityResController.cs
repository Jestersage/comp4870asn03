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
    public class CityResController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: CityRes
        public ActionResult Index()
        {
            return View(db.CityRes.ToList());
        }

        // GET: CityRes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityRes cityRes = db.CityRes.Find(id);
            if (cityRes == null)
            {
                return HttpNotFound();
            }
            return View(cityRes);
        }

        // GET: CityRes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityRes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityResId,CityResName")] CityRes cityRes)
        {
            if (ModelState.IsValid)
            {
                db.CityRes.Add(cityRes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cityRes);
        }

        // GET: CityRes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityRes cityRes = db.CityRes.Find(id);
            if (cityRes == null)
            {
                return HttpNotFound();
            }
            return View(cityRes);
        }

        // POST: CityRes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityResId,CityResName")] CityRes cityRes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cityRes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cityRes);
        }

        // GET: CityRes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityRes cityRes = db.CityRes.Find(id);
            if (cityRes == null)
            {
                return HttpNotFound();
            }
            return View(cityRes);
        }

        // POST: CityRes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CityRes cityRes = db.CityRes.Find(id);
            db.CityRes.Remove(cityRes);
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
