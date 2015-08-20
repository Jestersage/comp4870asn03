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
    public class ThirdPartyReportsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/ThirdPartyReports
        public IQueryable<ThirdPartyReport> GetThirdPartyReports()
        {
            return db.ThirdPartyReports;
        }

        // GET: api/ThirdPartyReports/5
        [ResponseType(typeof(ThirdPartyReport))]
        public IHttpActionResult GetThirdPartyReport(int id)
        {
            ThirdPartyReport thirdPartyReport = db.ThirdPartyReports.Find(id);
            if (thirdPartyReport == null)
            {
                return NotFound();
            }

            return Ok(thirdPartyReport);
        }

        // PUT: api/ThirdPartyReports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutThirdPartyReport(int id, ThirdPartyReport thirdPartyReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thirdPartyReport.ThirdPartyReportId)
            {
                return BadRequest();
            }

            db.Entry(thirdPartyReport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThirdPartyReportExists(id))
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

        // POST: api/ThirdPartyReports
        [ResponseType(typeof(ThirdPartyReport))]
        public IHttpActionResult PostThirdPartyReport(ThirdPartyReport thirdPartyReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ThirdPartyReports.Add(thirdPartyReport);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = thirdPartyReport.ThirdPartyReportId }, thirdPartyReport);
        }

        // DELETE: api/ThirdPartyReports/5
        [ResponseType(typeof(ThirdPartyReport))]
        public IHttpActionResult DeleteThirdPartyReport(int id)
        {
            ThirdPartyReport thirdPartyReport = db.ThirdPartyReports.Find(id);
            if (thirdPartyReport == null)
            {
                return NotFound();
            }

            db.ThirdPartyReports.Remove(thirdPartyReport);
            db.SaveChanges();

            return Ok(thirdPartyReport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ThirdPartyReportExists(int id)
        {
            return db.ThirdPartyReports.Count(e => e.ThirdPartyReportId == id) > 0;
        }
    }
}