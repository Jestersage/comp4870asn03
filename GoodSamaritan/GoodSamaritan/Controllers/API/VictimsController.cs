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

namespace GoodSamaritan.Controllers.API
{
    public class VictimsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/Victims
        public IQueryable<Victim> GetVictims()
        {
            return db.Victims;
        }

        // GET: api/Victims/5
        [ResponseType(typeof(Victim))]
        public IHttpActionResult GetVictim(int id)
        {
            Victim victim = db.Victims.Find(id);
            if (victim == null)
            {
                return NotFound();
            }

            return Ok(victim);
        }

        // PUT: api/Victims/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVictim(int id, Victim victim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != victim.VictimId)
            {
                return BadRequest();
            }

            db.Entry(victim).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VictimExists(id))
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

        // POST: api/Victims
        [ResponseType(typeof(Victim))]
        public IHttpActionResult PostVictim(Victim victim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Victims.Add(victim);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = victim.VictimId }, victim);
        }

        // DELETE: api/Victims/5
        [ResponseType(typeof(Victim))]
        public IHttpActionResult DeleteVictim(int id)
        {
            Victim victim = db.Victims.Find(id);
            if (victim == null)
            {
                return NotFound();
            }

            db.Victims.Remove(victim);
            db.SaveChanges();

            return Ok(victim);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VictimExists(int id)
        {
            return db.Victims.Count(e => e.VictimId == id) > 0;
        }
    }
}