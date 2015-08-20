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
    public class CrisesController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/Crises
        public IQueryable<Crisis> GetCrises()
        {
            return db.Crises;
        }

        // GET: api/Crises/5
        [ResponseType(typeof(Crisis))]
        public IHttpActionResult GetCrisis(int id)
        {
            Crisis crisis = db.Crises.Find(id);
            if (crisis == null)
            {
                return NotFound();
            }

            return Ok(crisis);
        }

        // PUT: api/Crises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCrisis(int id, Crisis crisis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != crisis.CrisisId)
            {
                return BadRequest();
            }

            db.Entry(crisis).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrisisExists(id))
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

        // POST: api/Crises
        [ResponseType(typeof(Crisis))]
        public IHttpActionResult PostCrisis(Crisis crisis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Crises.Add(crisis);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = crisis.CrisisId }, crisis);
        }

        // DELETE: api/Crises/5
        [ResponseType(typeof(Crisis))]
        public IHttpActionResult DeleteCrisis(int id)
        {
            Crisis crisis = db.Crises.Find(id);
            if (crisis == null)
            {
                return NotFound();
            }

            db.Crises.Remove(crisis);
            db.SaveChanges();

            return Ok(crisis);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CrisisExists(int id)
        {
            return db.Crises.Count(e => e.CrisisId == id) > 0;
        }
    }
}