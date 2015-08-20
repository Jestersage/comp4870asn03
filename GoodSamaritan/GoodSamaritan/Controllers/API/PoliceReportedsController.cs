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
    public class PoliceReportedsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/PoliceReporteds
        public IQueryable<PoliceReported> GetPoliceReporteds()
        {
            return db.PoliceReporteds;
        }

        // GET: api/PoliceReporteds/5
        [ResponseType(typeof(PoliceReported))]
        public IHttpActionResult GetPoliceReported(int id)
        {
            PoliceReported policeReported = db.PoliceReporteds.Find(id);
            if (policeReported == null)
            {
                return NotFound();
            }

            return Ok(policeReported);
        }

        // PUT: api/PoliceReporteds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoliceReported(int id, PoliceReported policeReported)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policeReported.PoliceReportedId)
            {
                return BadRequest();
            }

            db.Entry(policeReported).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliceReportedExists(id))
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

        // POST: api/PoliceReporteds
        [ResponseType(typeof(PoliceReported))]
        public IHttpActionResult PostPoliceReported(PoliceReported policeReported)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PoliceReporteds.Add(policeReported);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = policeReported.PoliceReportedId }, policeReported);
        }

        // DELETE: api/PoliceReporteds/5
        [ResponseType(typeof(PoliceReported))]
        public IHttpActionResult DeletePoliceReported(int id)
        {
            PoliceReported policeReported = db.PoliceReporteds.Find(id);
            if (policeReported == null)
            {
                return NotFound();
            }

            db.PoliceReporteds.Remove(policeReported);
            db.SaveChanges();

            return Ok(policeReported);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PoliceReportedExists(int id)
        {
            return db.PoliceReporteds.Count(e => e.PoliceReportedId == id) > 0;
        }
    }
}