using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GoodSamaritan.Models.Client;
using GoodSamaritan.Models.Smart;

namespace GoodSamaritan.Controllers.API
{
    public class BadDateReportsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/BadDateReports
        public IQueryable<BadDateReport> GetBadDateReports()
        {
            return db.BadDateReports;
        }

        // GET: api/BadDateReports/5
        [ResponseType(typeof(BadDateReport))]
        public IHttpActionResult GetBadDateReport(int id)
        {
            BadDateReport badDateReport = db.BadDateReports.Find(id);
            if (badDateReport == null)
            {
                return NotFound();
            }

            return Ok(badDateReport);
        }

        // PUT: api/BadDateReports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBadDateReport(int id, BadDateReport badDateReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != badDateReport.BadDateReportId)
            {
                return BadRequest();
            }

            db.Entry(badDateReport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BadDateReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BadDateReports
        [ResponseType(typeof(BadDateReport))]
        public IHttpActionResult PostBadDateReport(BadDateReport badDateReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BadDateReports.Add(badDateReport);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = badDateReport.BadDateReportId }, badDateReport);
        }

        // DELETE: api/BadDateReports/5
        [ResponseType(typeof(BadDateReport))]
        public IHttpActionResult DeleteBadDateReport(int id)
        {
            BadDateReport badDateReport = db.BadDateReports.Find(id);
            if (badDateReport == null)
            {
                return NotFound();
            }

            db.BadDateReports.Remove(badDateReport);
            db.SaveChanges();

            return Ok(badDateReport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BadDateReportExists(int id)
        {
            return db.BadDateReports.Count(e => e.BadDateReportId == id) > 0;
        }
    }
}