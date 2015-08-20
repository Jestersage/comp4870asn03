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
    public class AbuserRelationshipsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/AbuserRelationships
        public IQueryable<AbuserRelationship> GetAbuserRelationships()
        {
            return db.AbuserRelationships;
        }

        // GET: api/AbuserRelationships/5
        [ResponseType(typeof(AbuserRelationship))]
        public IHttpActionResult GetAbuserRelationship(int id)
        {
            AbuserRelationship abuserRelationship = db.AbuserRelationships.Find(id);
            if (abuserRelationship == null)
            {
                return NotFound();
            }

            return Ok(abuserRelationship);
        }

        // PUT: api/AbuserRelationships/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAbuserRelationship(int id, AbuserRelationship abuserRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != abuserRelationship.AbuserRelationshipId)
            {
                return BadRequest();
            }

            db.Entry(abuserRelationship).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbuserRelationshipExists(id))
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

        // POST: api/AbuserRelationships
        [ResponseType(typeof(AbuserRelationship))]
        public IHttpActionResult PostAbuserRelationship(AbuserRelationship abuserRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AbuserRelationships.Add(abuserRelationship);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = abuserRelationship.AbuserRelationshipId }, abuserRelationship);
        }

        // DELETE: api/AbuserRelationships/5
        [ResponseType(typeof(AbuserRelationship))]
        public IHttpActionResult DeleteAbuserRelationship(int id)
        {
            AbuserRelationship abuserRelationship = db.AbuserRelationships.Find(id);
            if (abuserRelationship == null)
            {
                return NotFound();
            }

            db.AbuserRelationships.Remove(abuserRelationship);
            db.SaveChanges();

            return Ok(abuserRelationship);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AbuserRelationshipExists(int id)
        {
            return db.AbuserRelationships.Count(e => e.AbuserRelationshipId == id) > 0;
        }
    }
}