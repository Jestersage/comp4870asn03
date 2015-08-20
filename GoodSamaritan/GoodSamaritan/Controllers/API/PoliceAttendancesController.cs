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
    public class PoliceAttendancesController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/PoliceAttendances
        public IQueryable<PoliceAttendance> GetPoliceAttendances()
        {
            return db.PoliceAttendances;
        }

        // GET: api/PoliceAttendances/5
        [ResponseType(typeof(PoliceAttendance))]
        public IHttpActionResult GetPoliceAttendance(int id)
        {
            PoliceAttendance policeAttendance = db.PoliceAttendances.Find(id);
            if (policeAttendance == null)
            {
                return NotFound();
            }

            return Ok(policeAttendance);
        }

        // PUT: api/PoliceAttendances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoliceAttendance(int id, PoliceAttendance policeAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policeAttendance.PoliceAttendanceId)
            {
                return BadRequest();
            }

            db.Entry(policeAttendance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliceAttendanceExists(id))
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

        // POST: api/PoliceAttendances
        [ResponseType(typeof(PoliceAttendance))]
        public IHttpActionResult PostPoliceAttendance(PoliceAttendance policeAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PoliceAttendances.Add(policeAttendance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = policeAttendance.PoliceAttendanceId }, policeAttendance);
        }

        // DELETE: api/PoliceAttendances/5
        [ResponseType(typeof(PoliceAttendance))]
        public IHttpActionResult DeletePoliceAttendance(int id)
        {
            PoliceAttendance policeAttendance = db.PoliceAttendances.Find(id);
            if (policeAttendance == null)
            {
                return NotFound();
            }

            db.PoliceAttendances.Remove(policeAttendance);
            db.SaveChanges();

            return Ok(policeAttendance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PoliceAttendanceExists(int id)
        {
            return db.PoliceAttendances.Count(e => e.PoliceAttendanceId == id) > 0;
        }
    }
}