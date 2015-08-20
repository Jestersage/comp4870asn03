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
    public class MultiplePerpetratorsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/MultiplePerpetrators
        public IQueryable<MultiplePerpetrator> GetMultiplePerpetrators()
        {
            return db.MultiplePerpetrators;
        }

        // GET: api/MultiplePerpetrators/5
        [ResponseType(typeof(MultiplePerpetrator))]
        public IHttpActionResult GetMultiplePerpetrator(int id)
        {
            MultiplePerpetrator multiplePerpetrator = db.MultiplePerpetrators.Find(id);
            if (multiplePerpetrator == null)
            {
                return NotFound();
            }

            return Ok(multiplePerpetrator);
        }

        // PUT: api/MultiplePerpetrators/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMultiplePerpetrator(int id, MultiplePerpetrator multiplePerpetrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != multiplePerpetrator.MultiplePerpetratorId)
            {
                return BadRequest();
            }

            db.Entry(multiplePerpetrator).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultiplePerpetratorExists(id))
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

        // POST: api/MultiplePerpetrators
        [ResponseType(typeof(MultiplePerpetrator))]
        public IHttpActionResult PostMultiplePerpetrator(MultiplePerpetrator multiplePerpetrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MultiplePerpetrators.Add(multiplePerpetrator);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = multiplePerpetrator.MultiplePerpetratorId }, multiplePerpetrator);
        }

        // DELETE: api/MultiplePerpetrators/5
        [ResponseType(typeof(MultiplePerpetrator))]
        public IHttpActionResult DeleteMultiplePerpetrator(int id)
        {
            MultiplePerpetrator multiplePerpetrator = db.MultiplePerpetrators.Find(id);
            if (multiplePerpetrator == null)
            {
                return NotFound();
            }

            db.MultiplePerpetrators.Remove(multiplePerpetrator);
            db.SaveChanges();

            return Ok(multiplePerpetrator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MultiplePerpetratorExists(int id)
        {
            return db.MultiplePerpetrators.Count(e => e.MultiplePerpetratorId == id) > 0;
        }
    }
}