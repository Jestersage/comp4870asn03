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
    public class VictimServicesAttendancesController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/VictimServicesAttendances
        public IQueryable<VictimServicesAttendance> GetVictimServicesAttendances()
        {
            return db.VictimServicesAttendances;
        }

        // GET: api/VictimServicesAttendances/5
        [ResponseType(typeof(VictimServicesAttendance))]
        public IHttpActionResult GetVictimServicesAttendance(int id)
        {
            VictimServicesAttendance victimServicesAttendance = db.VictimServicesAttendances.Find(id);
            if (victimServicesAttendance == null)
            {
                return NotFound();
            }

            return Ok(victimServicesAttendance);
        }

        // PUT: api/VictimServicesAttendances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVictimServicesAttendance(int id, VictimServicesAttendance victimServicesAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != victimServicesAttendance.VictimServicesAttendanceId)
            {
                return BadRequest();
            }

            db.Entry(victimServicesAttendance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VictimServicesAttendanceExists(id))
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

        // POST: api/VictimServicesAttendances
        [ResponseType(typeof(VictimServicesAttendance))]
        public IHttpActionResult PostVictimServicesAttendance(VictimServicesAttendance victimServicesAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VictimServicesAttendances.Add(victimServicesAttendance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = victimServicesAttendance.VictimServicesAttendanceId }, victimServicesAttendance);
        }

        // DELETE: api/VictimServicesAttendances/5
        [ResponseType(typeof(VictimServicesAttendance))]
        public IHttpActionResult DeleteVictimServicesAttendance(int id)
        {
            VictimServicesAttendance victimServicesAttendance = db.VictimServicesAttendances.Find(id);
            if (victimServicesAttendance == null)
            {
                return NotFound();
            }

            db.VictimServicesAttendances.Remove(victimServicesAttendance);
            db.SaveChanges();

            return Ok(victimServicesAttendance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VictimServicesAttendanceExists(int id)
        {
            return db.VictimServicesAttendances.Count(e => e.VictimServicesAttendanceId == id) > 0;
        }
    }
}