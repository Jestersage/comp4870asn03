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
    public class FileStatusController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: FileStatus
        public ActionResult Index()
        {
            return View(db.FileStatus.ToList());
        }

        // GET: FileStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileStatus fileStatus = db.FileStatus.Find(id);
            if (fileStatus == null)
            {
                return HttpNotFound();
            }
            return View(fileStatus);
        }

        // GET: FileStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FileStatusId,FileStatusString")] FileStatus fileStatus)
        {
            if (ModelState.IsValid)
            {
                db.FileStatus.Add(fileStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fileStatus);
        }

        // GET: FileStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileStatus fileStatus = db.FileStatus.Find(id);
            if (fileStatus == null)
            {
                return HttpNotFound();
            }
            return View(fileStatus);
        }

        // POST: FileStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FileStatusId,FileStatusString")] FileStatus fileStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fileStatus);
        }

        // GET: FileStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileStatus fileStatus = db.FileStatus.Find(id);
            if (fileStatus == null)
            {
                return HttpNotFound();
            }
            return View(fileStatus);
        }

        // POST: FileStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileStatus fileStatus = db.FileStatus.Find(id);
            db.FileStatus.Remove(fileStatus);
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
