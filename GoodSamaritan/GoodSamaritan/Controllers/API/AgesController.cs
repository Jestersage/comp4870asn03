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
    public class AgesController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/Ages
        public IQueryable<Age> GetAges()
        {
            return db.Ages;
        }

        // GET: api/Ages/5
        [ResponseType(typeof(Age))]
        public IHttpActionResult GetAge(int id)
        {
            Age age = db.Ages.Find(id);
            if (age == null)
            {
                return NotFound();
            }

            return Ok(age);
        }

        // PUT: api/Ages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAge(int id, Age age)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != age.AgeId)
            {
                return BadRequest();
            }

            db.Entry(age).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgeExists(id))
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

        // POST: api/Ages
        [ResponseType(typeof(Age))]
        public IHttpActionResult PostAge(Age age)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ages.Add(age);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = age.AgeId }, age);
        }

        // DELETE: api/Ages/5
        [ResponseType(typeof(Age))]
        public IHttpActionResult DeleteAge(int id)
        {
            Age age = db.Ages.Find(id);
            if (age == null)
            {
                return NotFound();
            }

            db.Ages.Remove(age);
            db.SaveChanges();

            return Ok(age);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgeExists(int id)
        {
            return db.Ages.Count(e => e.AgeId == id) > 0;
        }
    }
}