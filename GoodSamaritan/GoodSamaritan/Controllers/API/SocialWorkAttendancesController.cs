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
    public class SocialWorkAttendancesController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/SocialWorkAttendances
        public IQueryable<SocialWorkAttendance> GetSocialWorkAttendances()
        {
            return db.SocialWorkAttendances;
        }

        // GET: api/SocialWorkAttendances/5
        [ResponseType(typeof(SocialWorkAttendance))]
        public IHttpActionResult GetSocialWorkAttendance(int id)
        {
            SocialWorkAttendance socialWorkAttendance = db.SocialWorkAttendances.Find(id);
            if (socialWorkAttendance == null)
            {
                return NotFound();
            }

            return Ok(socialWorkAttendance);
        }

        // PUT: api/SocialWorkAttendances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSocialWorkAttendance(int id, SocialWorkAttendance socialWorkAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != socialWorkAttendance.SocialWorkAttendanceId)
            {
                return BadRequest();
            }

            db.Entry(socialWorkAttendance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialWorkAttendanceExists(id))
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

        // POST: api/SocialWorkAttendances
        [ResponseType(typeof(SocialWorkAttendance))]
        public IHttpActionResult PostSocialWorkAttendance(SocialWorkAttendance socialWorkAttendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SocialWorkAttendances.Add(socialWorkAttendance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = socialWorkAttendance.SocialWorkAttendanceId }, socialWorkAttendance);
        }

        // DELETE: api/SocialWorkAttendances/5
        [ResponseType(typeof(SocialWorkAttendance))]
        public IHttpActionResult DeleteSocialWorkAttendance(int id)
        {
            SocialWorkAttendance socialWorkAttendance = db.SocialWorkAttendances.Find(id);
            if (socialWorkAttendance == null)
            {
                return NotFound();
            }

            db.SocialWorkAttendances.Remove(socialWorkAttendance);
            db.SaveChanges();

            return Ok(socialWorkAttendance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SocialWorkAttendanceExists(int id)
        {
            return db.SocialWorkAttendances.Count(e => e.SocialWorkAttendanceId == id) > 0;
        }
    }
}