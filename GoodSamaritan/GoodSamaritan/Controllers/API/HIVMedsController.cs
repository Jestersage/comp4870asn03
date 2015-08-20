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
    public class HIVMedsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/HIVMeds
        public IQueryable<HIVMeds> GetHIVMeds()
        {
            return db.HIVMeds;
        }

        // GET: api/HIVMeds/5
        [ResponseType(typeof(HIVMeds))]
        public IHttpActionResult GetHIVMeds(int id)
        {
            HIVMeds hIVMeds = db.HIVMeds.Find(id);
            if (hIVMeds == null)
            {
                return NotFound();
            }

            return Ok(hIVMeds);
        }

        // PUT: api/HIVMeds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHIVMeds(int id, HIVMeds hIVMeds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hIVMeds.HIVMedsId)
            {
                return BadRequest();
            }

            db.Entry(hIVMeds).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HIVMedsExists(id))
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

        // POST: api/HIVMeds
        [ResponseType(typeof(HIVMeds))]
        public IHttpActionResult PostHIVMeds(HIVMeds hIVMeds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HIVMeds.Add(hIVMeds);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hIVMeds.HIVMedsId }, hIVMeds);
        }

        // DELETE: api/HIVMeds/5
        [ResponseType(typeof(HIVMeds))]
        public IHttpActionResult DeleteHIVMeds(int id)
        {
            HIVMeds hIVMeds = db.HIVMeds.Find(id);
            if (hIVMeds == null)
            {
                return NotFound();
            }

            db.HIVMeds.Remove(hIVMeds);
            db.SaveChanges();

            return Ok(hIVMeds);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HIVMedsExists(int id)
        {
            return db.HIVMeds.Count(e => e.HIVMedsId == id) > 0;
        }
    }
}